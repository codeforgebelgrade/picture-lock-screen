using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Codeforge.PictureLockCommons;
using System.Runtime.Serialization.Json;
using System.IO;

namespace PictureLockManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Image location");
            listView1.Columns[0].Width = 400;
            listView1.Columns.Add("Passphrase");
            listView1.GridLines = true; ;
        }

        /// <summary>
        /// Loads images from the selected folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath.Text = folderBrowserDialog1.SelectedPath;
                List<String> fileNames = System.IO.Directory.EnumerateFiles(folderBrowserDialog1.SelectedPath).ToList();
                listView1.Items.Clear();
                foreach (String filename in fileNames)
                {
                    ListViewItem item = new ListViewItem(new[] {filename, "" });
                    listView1.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Show selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EvtShowImage(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count >= 1)
            {
                // we should try to dispose old picture: https://stackoverflow.com/questions/39439942/dispose-of-a-picturebox-image-without-losing-the-picturebox
                if (pictureBox1.Image != null)
                {
                    System.Drawing.Image oldImage = pictureBox1.Image;
                    oldImage.Dispose();
                }

                pictureBox1.Image = null;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = listView1.SelectedItems[0].Text;
                pictureBox1.Show();
                tbPassphrase.Text = "";
            }
        }

        /// <summary>
        /// Set the passphrase for the currently selected image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPassphraseSet_Click(object sender, EventArgs e)
        {
            if (PicturesAreLoaded())
            {
                if (!tbPassphrase.Text.Trim().Equals(string.Empty))
                {
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    selectedItem.SubItems[1].Text = tbPassphrase.Text;
                }
                else
                {
                    MessageBox.Show("Passphrase must not be empty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You must load some pictures first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves image location list and passphrases into a JSON file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveFile_Click(object sender, EventArgs e)
        {
            if (PicturesAreLoaded() && PassphrasesAreSet())
            {

                PictureLockList imgList = new PictureLockList()
                {
                    PictureLockItems = new List<PictureLockList.PictureLockListItem>()
                };

                foreach (ListViewItem lvItem in listView1.Items)
                {
                    if (!lvItem.SubItems[1].Text.Trim().Equals(string.Empty))
                    {
                        PictureLockList.PictureLockListItem item = new PictureLockList.PictureLockListItem()
                        {
                            FilePath = lvItem.SubItems[0].Text,
                            Password = lvItem.SubItems[1].Text
                        };

                        imgList.PictureLockItems.Add(item);
                    }
                }

                using (FileStream fs = new FileStream("images.json", FileMode.Create))
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(PictureLockList));
                    js.WriteObject(fs, imgList);
                }
            }
            else
            {
                MessageBox.Show("You must load some pictures or set at least one passphrase!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Checks if any pictures are loaded
        /// </summary>
        /// <returns>Boolean value showing if any pictures are loaded</returns>
        private bool PicturesAreLoaded()
        {
            if (listView1.Items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if any passphrases are set
        /// </summary>
        /// <returns>Boolean value showing if any passphrases are set</returns>
        private bool PassphrasesAreSet()
        {
            bool passPhraseSet = false;
            foreach (ListViewItem lvItem in listView1.Items)
            {
                if(!lvItem.SubItems[0].Text.Trim().Equals(string.Empty))
                {
                    passPhraseSet = true;
                }
            }

            return passPhraseSet;
        }
    }
}
