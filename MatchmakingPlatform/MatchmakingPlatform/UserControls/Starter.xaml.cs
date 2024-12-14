using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace MatchmakingPlatform.UserControls
{
    public partial class Starter : Window
    {
        public Starter()
        {
            InitializeComponent();
            AddControls();
            MessageBox.Show("hello world");
        }

        

        void AddControls()
        {
            DatabaseItem expandingControl1 = new DatabaseItem
            {
                Width = 100,
                Height = 100
            };

            // Add it to the Grid (or any other container)
            MainGrid.Children.Add(expandingControl1);

            // You can create more instances similarly and add them to the grid
            //DatabaseItem expandingControl2 = new DatabaseItem
            //{
            //    Width = 120,
            //    Height = 120
            //};

            //expandingControl2.ImageBrush = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\musno\\OneDrive\\Desktop\\SEMESTER 3\\DSA\\Projects\\DSA-FINAL-PROJECT\\MatchmakingPlatform\\MatchmakingPlatform\\Data\\Female Images\\noor_ProfilePicture.jpeg", UriKind.RelativeOrAbsolute)));
            //MainGrid.Children.Add(expandingControl2);

        }
        // Optionally set properties like ImageBrush
    }


}
