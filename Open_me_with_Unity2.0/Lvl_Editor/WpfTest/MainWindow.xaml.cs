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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Windows.Controls.Image;

namespace WpfTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bitmap image1;
        private bool thereIsTheFlag = false;
        private System.Windows.Media.Color penColor = System.Windows.Media.Color.FromArgb(255, 255, 255, 255);
        public void loadImage()
        {



            image1 = new Bitmap(50,20);


            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    if (y == 18)
                    {
                        System.Drawing.Color myColor1 = System.Drawing.Color.FromArgb(0, 0, 0);
                        image1.SetPixel(x, y, myColor1);
                    }
                    else
                    {
                        System.Drawing.Color myColor1 = System.Drawing.Color.FromArgb(255, 255, 255);
                        image1.SetPixel(x, y, myColor1);
                    }
                    
                }
            }

                   
        }

        public void openLvlFromFile()
        {

           /* string currentPath = Directory.GetCurrentDirectory();
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

            image1 = new Bitmap(levels[0], true);//par defaut, j ouvre le premier fichier png et apres je recolorie */
            
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
                string fullPath = currentPath + @"\"+"The Answer_Data"+ @"\" + "lvlEditor"+ @"\" + imageName + ".png";
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


        public void init_Panels()
        {
            int iRow = -1;
            foreach(RowDefinition row in myImageGrid.RowDefinitions)
            {
                iRow++;
                int iCol = -1;
                foreach(ColumnDefinition col in myImageGrid.ColumnDefinitions)
                {
                    iCol++;
                    Image panel = new Image();// a terme faudra remplacer ca par une image
                    Grid.SetColumn(panel, iCol);
                    Grid.SetRow(panel, iRow);

                    panel.MouseEnter += Panel_MouseEnter;
                    
                    panel.MouseDown += Panel_Clicked;
                    
                    


                    byte a = image1.GetPixel(iCol, iRow).A;
                    byte r = image1.GetPixel(iCol, iRow).R;
                    byte g = image1.GetPixel(iCol, iRow).G;
                    byte b = image1.GetPixel(iCol, iRow).B;

                    System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(a, r, g, b);

                    ConvertColorToImage(color, panel);

                  
                    myImageGrid.Children.Add(panel);
                    
                }

            }
        }

        private void ConvertColorToImage(System.Windows.Media.Color color, Image panel)
        {
            System.Windows.Media.Color blueCochon = System.Windows.Media.Color.FromArgb(255, 0, 0, 255);
            System.Windows.Media.Color grayFantome = System.Windows.Media.Color.FromArgb(255, 0, 255, 0);
            System.Windows.Media.Color blackPlateforme = System.Windows.Media.Color.FromArgb(255, 0, 0, 0);
            System.Windows.Media.Color redFlag = System.Windows.Media.Color.FromArgb(255, 255, 0, 0);

            BitmapImage result = new BitmapImage();
            

            if (color.Equals(blueCochon))
            {
                result.BeginInit();
                result.UriSource = new Uri("cochon_image.png", UriKind.Relative);
                result.EndInit();

            }
            else if (color.Equals(grayFantome))
            {
                result.BeginInit();
                result.UriSource = new Uri("fantome_image.png", UriKind.Relative);
                result.EndInit();
            }
            else if (color.Equals(blackPlateforme))
            {
                result.BeginInit();
                result.UriSource = new Uri("plateforme_image.png", UriKind.Relative);
                result.EndInit();
            }
            else if (color.Equals(redFlag))
            {
                result.BeginInit();
                result.UriSource = new Uri("drapeau.png", UriKind.Relative);
                result.EndInit();
            }
            else if (color.B==0 && color.R == 0 && color.G == 0)
            {
                result.BeginInit();
                result.UriSource = new Uri("whiteNothing_image.png", UriKind.Relative);
                result.EndInit();
            }
            else
            {
                result.BeginInit();
                result.UriSource = new Uri("whiteNothing_image.png", UriKind.Relative);
                result.EndInit();
            }

            panel.Source = result;

        }
        
        private void Panel_MouseEnter(Object sender, MouseEventArgs e)
        {
            if (System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Panel_Clicked(sender, e);
            }
           

        }

        private void Panel_Clicked(Object sender, MouseEventArgs e)
        {

            Image panel = sender as Image;

            int sCol = Grid.GetColumn(panel);
            int sRow = Grid.GetRow(panel);


            

            byte alpha = penColor.A;
            byte red = penColor.R;
            byte green = penColor.G;
            byte blue = penColor.B;

            if (thereIsTheFlag && red ==255 && green==0 && blue == 0)
            {
                MessageBox.Show("There arleady is a flag");
            }
            else
            {
                ConvertColorToImage(penColor, panel);// dessine l image 

                if (image1.GetPixel(sCol, sRow).R==255 && image1.GetPixel(sCol, sRow).B == 0 && image1.GetPixel(sCol, sRow).G == 0
                    && (red != 255 || green!=0 || blue!= 0))
                {
                    // on efface notre drapeau
                    Console.WriteLine("on efface");
                    thereIsTheFlag = false;
                }

                image1.SetPixel(sCol, sRow, System.Drawing.Color.FromArgb(alpha, red, green, blue));

                
                if (red == 255 && green == 0 && blue == 0)
                {
                    thereIsTheFlag = true;// on met le flag

                    Console.WriteLine("on le met");
                }
            }
           
        }

        private void MapItem_Click(object sender, RoutedEventArgs e)
        {
           UIElementCollection uIElementCollection = ((StackPanel)((Button)sender).Content).Children;
           
        }

     
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadImage();
            init_Panels();
          
        }
        

        public void Gomme_Clicked(Object sender, MouseEventArgs e)
        {
            penColor = System.Windows.Media.Color.FromArgb(255, 255, 255, 255);
        }

        public void Plateforme_Clicked(Object sender, MouseEventArgs e)
        {
            penColor = System.Windows.Media.Color.FromArgb(255, 0, 0, 0);
        }

        public void Cochon_Clicked(Object sender, MouseEventArgs e)
        {
            penColor = System.Windows.Media.Color.FromArgb(255, 0, 0, 255);
        }

        public void Fantome_Clicked(Object sender, MouseEventArgs e)
        {
            penColor = System.Windows.Media.Color.FromArgb(255, 0, 255, 0);
        }

        public void Joueur_Clicked(Object sender, MouseEventArgs e)
        {
            penColor = System.Windows.Media.Color.FromArgb(255, 255, 0, 0);
        }

        

    }

        
}
