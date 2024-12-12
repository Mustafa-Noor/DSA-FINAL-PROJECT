using System;
using System.Windows;
using MatchmakingPlatform.DL;
using MatchmakingPlatform;
using System.Runtime.ExceptionServices;

namespace MatchmakingPlatform.BL
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        // Register Button Click Event
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous error messages
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;

            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;
            if (Validations.CheckforEmpty(NameTextBox.Text) || Validations.CheckingForSpace(NameTextBox.Text))
            {
                ErrorMessageTextBlock.Text = "Username cannot be empty or contain spaces.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else if (Validations.CheckforEmpty(PasswordTextBox.Text) || Validations.CheckingForSpace(PasswordTextBox.Text) || !Validations.CheckingPasswordLength(PasswordTextBox.Text) || !Validations.CheckForInteger(PasswordTextBox.Text))
            {
                ErrorMessageTextBlock.Text = "Password cannot be empty and should 6 digits.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else if (Validations.CheckforEmpty(EmailTextBox.Text) || !Validations.ValidateEmailPattern(EmailTextBox.Text))
            {
                ErrorMessageTextBlock.Text = "Email should be in proper format.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else if (Validations.CheckforEmpty(GenderComboBox.Text))
            {
                ErrorMessageTextBlock.Text = "Gender box should not be empty.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else if (DobDatePicker.SelectedDate == null)
            {
                ErrorMessageTextBlock.Text = "Date of Birth must be selected.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;

                
            }
            else if (!Validations.IsAtLeast18YearsOld(DobDatePicker.SelectedDate.Value))
            {
                
                ErrorMessageTextBlock.Text = "You must be at least 18 years old to register.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else if (Validations.CheckforEmpty(PhoneNumberTextBox.Text) || !Validations.ValidateContactPattern(PhoneNumberTextBox.Text))
            {
                ErrorMessageTextBlock.Text = "Phone Number should be in the correct Pk Format.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else
            {

                if(GenderComboBox.Text == "Male")
                {
                    Male user = new Male(
                       NameTextBox.Text,
                       PasswordTextBox.Text,
                       EmailTextBox.Text,
                       PhoneNumberTextBox.Text,
                       DobDatePicker.SelectedDate.Value,
                       GenderComboBox.Text);


                    if (MaleDL.AddUser(user))
                    {
                        MessageBox.Show("Registration Successful");
                        NameTextBox.Text = string.Empty;
                        PasswordTextBox.Text = string.Empty;
                        EmailTextBox.Text = string.Empty;
                        PhoneNumberTextBox.Text = string.Empty;
                        DobDatePicker.SelectedDate = null;
                        GenderComboBox.SelectedItem = null;
                        ErrorMessageTextBlock.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageBox.Show("Username already exist!");

                    }
                }
                else
                {
                    Female user = new Female(
                       NameTextBox.Text,
                       PasswordTextBox.Text,
                       EmailTextBox.Text,
                       PhoneNumberTextBox.Text,
                       DobDatePicker.SelectedDate.Value,
                       GenderComboBox.Text);


                    if (FemaleDL.AddUser(user))
                    {
                        MessageBox.Show("Registration Successful");
                        NameTextBox.Text = string.Empty;
                        PasswordTextBox.Text = string.Empty;
                        EmailTextBox.Text = string.Empty;
                        PhoneNumberTextBox.Text = string.Empty;
                        DobDatePicker.SelectedDate = null;
                        GenderComboBox.SelectedItem = null;
                        ErrorMessageTextBlock.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageBox.Show("Username already exist!");

                    }
                }



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
