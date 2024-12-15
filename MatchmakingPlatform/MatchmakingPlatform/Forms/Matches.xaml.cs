using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.Forms
{
    public partial class Matches : Window
    {
        HashSet<Male> males;
        public Matches(HashSet<Male> males)
        {
            this.males = males;
            InitializeComponent();
            LoadImages();
        }
        private void LoadImages()
        {
            foreach(Male male in males)
            {
                // Create an Ellipse
                Ellipse ellipse = new Ellipse
                {
                    Width = 100,
                    Height = 100,
                    Margin = new Thickness(10),
                    Stroke = Brushes.Gray,
                    StrokeThickness = 2
                };

                if(male.Image == null) {
                    ellipse.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("E:\\Studies\\3rd Samester\\DSAFinal\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform\\Data\\Male Images\\MaleDefaultImage.jpg",UriKind.Absolute)),
                    Stretch = Stretch.UniformToFill
                };
                }else{
                    ellipse.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(male.Image,UriKind.Absolute)),
                    Stretch = Stretch.UniformToFill
                };
                }
                //tooltip
                ellipse.ToolTip = $"{male.UserName} \n {male.Age}";

                // Attach the click event handler
                ellipse.MouseLeftButtonDown += (s, e) => ImageClicked(male);

                ImageWrapPanel.Children.Add(ellipse);
            }
        }

        private void ImageClicked(Male male)
        {
            MessageBox.Show($"Image clicked: {male.UserName}");
        }
    }
}
