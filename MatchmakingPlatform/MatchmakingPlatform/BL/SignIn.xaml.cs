using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;

namespace MatchmakingPlatform.BL
{
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        // Handle Sign In button click
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // Basic Validation: Check if the fields are empty
            if (string.IsNullOrEmpty(UsernameTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                ErrorMessageTextBlock.Text = "Both fields are required!";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                // Example hardcoded credentials
                string validUsername = "user123"; // Example username
                string validPassword = "password"; // Example password

                if (UsernameTextBox.Text == validUsername && PasswordBox.Password == validPassword)
                {
                    ErrorMessageTextBlock.Visibility = Visibility.Collapsed;
                    MessageBox.Show("Sign In Successful!");
                    // Proceed to the next page or functionality after successful sign-in
                    this.Close(); // Close the current Sign In window
                    // Open main window here if needed
                }
                else
                {
                    ErrorMessageTextBlock.Text = "Invalid Username or Password!";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        // Handle Register button click to navigate to the Register page
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Open Register page and close the Sign In page
            Register registerWindow = new Register(); // Assuming the Register window class is named "Register"
            registerWindow.Show();
            this.Close(); // Close the Sign In page
        }
    }
}
