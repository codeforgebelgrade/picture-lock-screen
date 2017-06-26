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
            List<String> fileNames = System.IO.Directory.EnumerateFiles("D:\\DropboxItems\\Dropbox\\Photos\\Wallpapers").ToList();

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
            }

            //Random random = new Random();
            //int index = random.Next(0, fileNames.Count);
            //pictureBox1.BackgroundImage = Image.FromFile(fileNames[index]);
            //image.Source = new BitmapImage(new Uri(fileNames[index]));
        }
    }
}
