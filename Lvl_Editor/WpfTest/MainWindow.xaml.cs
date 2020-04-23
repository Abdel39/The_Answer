using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Color = System.Drawing.Color;
using Image = System.Windows.Controls.Image;

namespace WpfTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap image1;
        public void loadImage()
        {
            /*byte[] photoInBytes = File.ReadAllBytes("kjn");
            bool mapAvaiable = this.map.LoadImage(photoInBytes);*/


            string currentPath = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(currentPath);
            List<String> levels = new List<string>();



            for (int i = 0; i < files.Length; i++)
            {
                string currentFile = files[i];
                int length = currentFile.Length;


                if (files[i].Substring(length - 4, 4).Equals(".png"))
                {
                    levels.Add(currentFile);

                }

            }

            image1 = new Bitmap(levels[0], true);//par defaut, j ouvre le premier fichier png

            Color newColor = Color.FromArgb(100, 100, 100);
            //image1.SetPixel(0, 0, newColor);
            //int x, y;

            // Loop through the images pixels to reset color.
            /*for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    Color pixelColor = image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    image1.SetPixel(x, y, newColor);
                }
            }*/
                   
        }

        public void printImage()
        {
            // Set the PictureBox to display the image.
            //PictureBox1.Image = image1;
            //Image image = myBitmapImage;
           // myBitmapImage.Source = this.myBitmapImage;
        }

       
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
      
      
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string imageName = lvlName.Text;
            if (imageName.Trim(' ').Equals(""))
            {
                MessageBox.Show("Please, give it a name");
            }
            else if (ContainsWeirdChars(imageName))
            {
                MessageBox.Show("The level name should contain only letters and numbers");
            }
            else if (!IsNameAvailable(imageName))
            {
                MessageBox.Show("This level name is already taken");
            }
            else
            {
                string currentPath = Directory.GetCurrentDirectory();
                string fullPath = currentPath + @"\" + imageName + ".png";
                image1.Save(fullPath);

                System.Windows.Application.Current.Shutdown();// arrete le programme 
                //plutot appeller this.close() depuis App quand je saurai comment faire
                               
            }
           
        }

        private bool ContainsWeirdChars(string text)
        {
            bool result = false;

            int i = 0;
            while (i<text.Length && !result)
            {
                result = !IsCorrectChar(text[i]);
                i++;
            }
            return result;
        }

        private bool IsCorrectChar(char a)
        {
            return (a >= 65 && a <= 90) || (a >= 97 && a <= 122) || (a >= 48 && a <= 57);
        }

        private bool IsNameAvailable(string nameWanted)
        {
            string currentPath = Directory.GetCurrentDirectory();

            Console.WriteLine(currentPath + @"\" + nameWanted + ".png");
            
            return !File.Exists(currentPath + @"\" + nameWanted + ".png");
            
        }

       
        private void MapItem_Click(object sender, RoutedEventArgs e)
        {
           UIElementCollection uIElementCollection = ((StackPanel)((Button)sender).Content).Children;
           

           
        }

     
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadImage();
        }

        private void LvlName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
