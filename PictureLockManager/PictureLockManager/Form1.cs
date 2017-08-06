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
            listView1.Columns.Add("C1");
            listView1.Columns.Add("C2");
            listView1.GridLines = true; ;
            
            /*List<String> fileNames = System.IO.Directory.EnumerateFiles("D:\\DropboxItems\\Dropbox\\Photos\\Wallpapers").ToList();
            PictureLockList imgList = new PictureLockList()
            {
                PictureLockItems = new List<PictureLockList.PictureLockListItem>()
            };

            foreach (String fileName in fileNames)
            {
                PictureLockList.PictureLockListItem item = new PictureLockList.PictureLockListItem()
                {
                    FilePath = fileName,
                    Password = "blah"
                };

                imgList.PictureLockItems.Add(item);
            }

            using (FileStream fs = new FileStream("images.json", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(PictureLockList));
                js.WriteObject(fs, imgList);
            }*/

            //Random random = new Random();
            //int index = random.Next(0, fileNames.Count);
            //pictureBox1.BackgroundImage = Image.FromFile(fileNames[index]);
            //image.Source = new BitmapImage(new Uri(fileNames[index]));
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath.Text = folderBrowserDialog1.SelectedPath;
                List<String> fileNames = System.IO.Directory.EnumerateFiles(folderBrowserDialog1.SelectedPath).ToList();
                listView1.Items.Clear();
                foreach (String filename in fileNames)
                {
                    ListViewItem item = new ListViewItem(new[] {filename, "blah" });
                    listView1.Items.Add(item);
                }
            }
        }

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
            }
        }

        private void BtnPassphraseSet_Click(object sender, EventArgs e)
        {
            if (!tbPassphrase.Text.Equals(string.Empty))
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.SubItems[1].Text = tbPassphrase.Text;
            }
            else
            {
                MessageBox.Show("Passphrase must not be empty", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
