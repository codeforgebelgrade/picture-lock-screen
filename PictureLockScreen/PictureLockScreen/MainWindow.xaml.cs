using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Json;
using Codeforge.PictureLockCommons;
using System.IO;
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

            try
            {
                
                String settingsFilepath = System.Configuration.ConfigurationManager.AppSettings["jsonFilePath"];
                var jsonSerializer = new DataContractJsonSerializer(typeof(PictureLockList));
                PictureLockList pictureLockList = jsonSerializer.ReadObject(File.OpenRead(settingsFilepath + "images.json")) as PictureLockList;
                List<PictureLockListItem> pictureLockItems = pictureLockList.PictureLockItems;

                Random random = new Random();
                int index = random.Next(0, pictureLockItems.Count);
                currentPicture = pictureLockItems[index];
                image.Source = new BitmapImage(new Uri(pictureLockItems[index].FilePath));
            } 
            catch (FileNotFoundException)
            {
                MessageBox.Show("Settings file is missing!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
            
        }

        /// <summary>
        /// Compares the user input to the passpharase of the corresponding picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
