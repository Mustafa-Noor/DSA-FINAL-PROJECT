using System;
using System.Windows;

namespace MatchmakingPlatform.BL
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        // Register Button Click Event
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous error messages
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;

            // Validation
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                GenderComboBox.SelectedItem == null ||
                DobDatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                ErrorMessageTextBlock.Text = "Please fill in all the required fields.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                // Logic for registration, like saving the data or connecting to the backend.
                MessageBox.Show("Registration Successful");
            }
        }

        // Sign-In Button Click Event
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the SignIn window
            SignIn signInWindow = new SignIn();
            signInWindow.Show(); // Show the SignIn window

            this.Close(); // Close the Register window
        }
    }
}
