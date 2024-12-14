using MatchmakingPlatform.DL;
using MatchmakingPlatform.Forms;
using System.Windows;

namespace MatchmakingPlatform.BL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaleDL.LoadDAta();
            FemaleDL.LoadDAta();
        }

        private void OpenRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
        }
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            //Create an instance of the SignIn window
            SignIn signInWindow = new SignIn();
            signInWindow.Show();
            this.Close();

        }
    }
} 