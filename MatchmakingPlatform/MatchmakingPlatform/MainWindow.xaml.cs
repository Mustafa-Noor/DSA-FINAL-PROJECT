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
            //    Female female = new Female(
            //    username: "john_doe",
            //    password: "password123",
            //    email: "john.doe@example.com",
            //    phoneNumber: "123-456-7890",
            //    dateOfBirth: new DateTime(1990, 5, 1),
            //    gender: "Female"
            //);
            //Forms.FemaleProfile registerWindow = new Forms.FemaleProfile(female);
            //Forms.MaleProfile registerWindow = new Forms.MaleProfile();
            // Show the Register window
            registerWindow.Show();
        }
        private void SignIn_Click(object sender, RoutedEventArgs e){
            // Create an instance of the SignIn window
            SignIn signInWindow = new SignIn();
            signInWindow.Show(); // Show the SignIn window

            this.Close(); // Close the Register window
        }
    }
}
