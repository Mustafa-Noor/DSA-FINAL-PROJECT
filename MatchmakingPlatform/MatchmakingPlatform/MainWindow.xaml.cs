using System.Windows;

namespace MatchmakingPlatform.BL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Register window
            Register registerWindow = new Register();

            // Show the Register window
            registerWindow.Show();
        }
    }
}
