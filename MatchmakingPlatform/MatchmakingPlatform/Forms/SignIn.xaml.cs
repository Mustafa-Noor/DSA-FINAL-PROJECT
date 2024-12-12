using System.Windows.Controls;
using System.Windows;
using MatchmakingPlatform.DL;
using MatchmakingPlatform.Forms;

namespace MatchmakingPlatform.BL
{
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;

            if (Validations.CheckforEmpty(UsernameTextBox.Text) || Validations.CheckingForSpace(UsernameTextBox.Text))
            {
                ErrorMessageTextBlock.Text = "Username cannot be empty or contain spaces.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            }
            else if (Validations.CheckforEmpty(PasswordBox1.Password) || Validations.CheckingForSpace(PasswordBox1.Password) || !Validations.CheckingPasswordLength(PasswordBox1.Password) || !Validations.CheckForInteger(PasswordBox1.Password))
            {
                ErrorMessageTextBlock.Text = "Password should be 6 digits.";
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
            } 
            else
            {
                if (MaleDL.CheckUserExists(UsernameTextBox.Text) || FemaleDL.CheckUserExists(UsernameTextBox.Text))
                {
                    if (MaleDL.CheckUserExists(UsernameTextBox.Text))
                    {
                        Male user = MaleDL.FindUser(UsernameTextBox.Text);
                        if(user != null)
                        {
                            if (user.CheckPassword(PasswordBox1.Password))
                            {
                                MaleProfile maleWindow = new MaleProfile(user);
                                maleWindow.Show(); // Show the SignIn window

                                this.Close();
                            }
                            else
                            {
                                ErrorMessageTextBlock.Text = "Incorrect Password";
                                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                            }
                       
                        }
                    }
                    else if (FemaleDL.CheckUserExists(UsernameTextBox.Text))
                    {
                        Female user = FemaleDL.FindUser(UsernameTextBox.Text);
                        if (user != null)
                        {
                            if(user.CheckPassword(PasswordBox1.Password))
                            {
                                FemaleProfile femaleWindow = new FemaleProfile(user);
                                femaleWindow.Show(); // Show the SignIn window

                                this.Close(); // Close the Register window
                            }
                            else
                            {
                                ErrorMessageTextBlock.Text = "Incorrect Password";
                                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                            }
                        }
                    }

                }
                else
                {
                    ErrorMessageTextBlock.Text = "User does not exist!";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Close(); // Close the Sign In page
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
