using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictureLockScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<String> fileNames = System.IO.Directory.EnumerateFiles("D:\\DropboxItems\\Dropbox\\Photos\\Wallpapers").ToList();
            Random random = new Random();
            int index = random.Next(0, fileNames.Count);
            image.Source = new BitmapImage(new Uri(fileNames[index]));
        }
    }
}
