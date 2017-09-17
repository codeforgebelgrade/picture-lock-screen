using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Json;
using System.Configuration;
using Codeforge.PictureLockCommons;
using System.IO;
using System.Text;
using static Codeforge.PictureLockCommons.PictureLockList;

namespace PictureLockScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private PictureLockListItem currentPicture = null;

        public MainWindow()
        {
            InitializeComponent();

            String settingsFilepath = System.Configuration.ConfigurationManager.AppSettings["jsonFilePath"];

            var jsonSerializer = new DataContractJsonSerializer(typeof(PictureLockList));
            object objResponse = jsonSerializer.ReadObject(File.OpenRead(settingsFilepath + "images.json"));
            PictureLockList pictureLockList = objResponse as PictureLockList;

            List<PictureLockListItem> pictureLockItems = pictureLockList.PictureLockItems;
            Random random = new Random();
            int index = random.Next(0, pictureLockItems.Count);
            currentPicture = pictureLockItems[index];
            image.Source = new BitmapImage(new Uri(pictureLockItems[index].FilePath));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string passphrase = this.tbAnswer.Text;
            if(passphrase.ToLower().Equals(currentPicture.Password))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("You answer is not correct!", "Error!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
