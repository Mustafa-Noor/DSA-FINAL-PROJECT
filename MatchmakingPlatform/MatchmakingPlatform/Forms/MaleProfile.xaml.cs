using MatchmakingPlatform.Extras;
using System.Windows;
using System.Windows.Media.Imaging;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.Forms
{
    public partial class MaleProfile : Window
    {
        HashSet<string> preferences = new HashSet<string>();
        private Male maleProfile;

        // Flag to track edit state
        private bool isEditing = false;

        public MaleProfile(Male male)
        {
            InitializeComponent();
            maleProfile = male;  // Initialize the male profile with the provided Male object
            PopulateFields();
            WindowState = WindowState.Maximized;
        }

        // Edit Info Button
        private void EditInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                EnableFields();
                EditInfoButton.Content = "Cancel Edit";
                CancelButton.Content = "Clear";
                isEditing = true;
            }
            else
            {
                // Disable all input fields and reset button text
                DisableFields();
                EditInfoButton.Content = "Edit Info";
                CancelButton.Content = "Next";
                isEditing = false;
            }
        }

        private void PopulateFields()
        {
            if (maleProfile != null)
            {
                FirstNameTextBox.Text = maleProfile.FirstName;
                LastNameTextBox.Text = maleProfile.LastName;
                EmailTextBox.Text = maleProfile.Email;
                ContactNumberTextBox.Text = maleProfile.ContactNumber;
                AddressTextBox.Text = maleProfile.Address;
                CityTextBox.Text = maleProfile.City;
                ProfessionTextBox.Text = maleProfile.Profession;
                HeightTextBox.Text = maleProfile.Height.ToString();
                EducationComboBox.SelectedItem = maleProfile.Education;
                SalaryTextBox.Text = maleProfile.Salary.ToString();

                if (maleProfile.Image != null)
                {
                    try
                    {
                        ProfileImage.Source = maleProfile.Image; //Assign directly
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load profile image.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        // Save Button
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                //MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isEditing)
            {
                MessageBox.Show("Select editing Option", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            maleProfile.FirstName = FirstNameTextBox.Text;
            maleProfile.LastName = LastNameTextBox.Text;
            maleProfile.Email = EmailTextBox.Text;
            maleProfile.ContactNumber = ContactNumberTextBox.Text;
            maleProfile.Address = AddressTextBox.Text;
            maleProfile.City = CityTextBox.Text;
            maleProfile.Profession = ProfessionTextBox.Text;
            maleProfile.Height = float.Parse(HeightTextBox.Text);
            maleProfile.Education = EducationComboBox.SelectedItem.ToString();
            maleProfile.Salary = float.Parse(SalaryTextBox.Text);

            // Optionally, if you're handling the profile image:
            if (ProfileImage.Source != null)
            {
                maleProfile.Image = (BitmapImage)ProfileImage.Source;
            }


            // Disable fields after saving
            DisableFields();
            isEditing = false;
        }

        // Cancel Button
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if(isEditing)
            {
                ResetFields();
                DisableFields();

                CancelButton.Content = "Next";
                EditInfoButton.Content = "Edit Info";
                isEditing = false;
            }
            else
            {
                //Conent for the next window
                this.Close();
            }
        }
        private void DisableFields()
        {
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            ContactNumberTextBox.IsEnabled = false;
            AddressTextBox.IsEnabled = false;
            CityTextBox.IsEnabled = false;
            ProfessionTextBox.IsEnabled = false;
            HeightTextBox.IsEnabled = false;
            EducationComboBox.IsEnabled = false;
            SalaryTextBox.IsEnabled = false; // Disable Salary TextBox
        }

        private void EnableFields()
        {
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            ContactNumberTextBox.IsEnabled = true;
            AddressTextBox.IsEnabled = true;
            CityTextBox.IsEnabled = true;
            ProfessionTextBox.IsEnabled = true;
            HeightTextBox.IsEnabled = true;
            EducationComboBox.IsEnabled = true;
            SalaryTextBox.IsEnabled = true; // Disable Salary TextBox
        }

        private void ResetFields()
        {
            // Reset fields to default or previously saved values
            FirstNameTextBox.Text = ""; // Replace with the original value if available
            LastNameTextBox.Text = "";
            EmailTextBox.Text = "";
            ContactNumberTextBox.Text = "";
            AddressTextBox.Text = "";
            CityTextBox.Text = "";
            HeightTextBox.Text = "";
            ProfessionTextBox.Text = "";
            EducationComboBox.SelectedIndex = -1; // Reset ComboBox selection
            SalaryTextBox.Text = ""; // Reset Salary TextBox
        }

        // Validation Function
        private bool ValidateFields()
        {

            if (isEditing)
            {
                ErrorMessage.Visibility = Visibility.Collapsed; // Hide error message initially

                // Validate first name
                if (Validations.CheckforEmpty(FirstNameTextBox.Text) || Validations.CheckingForSpace(FirstNameTextBox.Text))
                {
                    ShowErrorMessage("First Name cannot be empty or contain spaces.");
                    return false;
                }

                // Validate last name
                if (Validations.CheckforEmpty(LastNameTextBox.Text) || Validations.CheckingForSpace(LastNameTextBox.Text))
                {
                    ShowErrorMessage("Last Name cannot be empty or contain spaces.");
                    return false;
                }

                // Validate email
                if (Validations.CheckforEmpty(EmailTextBox.Text) || !Validations.ValidateEmailPattern(EmailTextBox.Text))
                {
                    ShowErrorMessage("Email should be in the proper format.");
                    return false;
                }

                // Validate contact number
                if (Validations.CheckforEmpty(ContactNumberTextBox.Text) || !Validations.ValidateContactPattern(ContactNumberTextBox.Text))
                {
                    ShowErrorMessage("Phone Number should be in the correct format.");
                    return false;
                }

                // Validate address
                if (Validations.CheckforEmpty(AddressTextBox.Text))
                {
                    ShowErrorMessage("Address cannot be empty.");
                    return false;
                }

                // Validate city
                if (Validations.CheckforEmpty(CityTextBox.Text))
                {
                    ShowErrorMessage("City cannot be empty.");
                    return false;
                }


                // Validate height
                if (Validations.CheckforEmpty(HeightTextBox.Text) || !double.TryParse(HeightTextBox.Text, out double height) || height <= 0)
                {
                    ShowErrorMessage("Please enter a valid height.");
                    return false;
                }

                // Validate education selection
                if (EducationComboBox.SelectedIndex == -1)
                {
                    ShowErrorMessage("Please select your education.");
                    return false;
                }

                // Validation passed
                return true;
            }

            return false;
        }

        // Helper method to show error messages
        private void ShowErrorMessage(string message)
        {
            ErrorMessage.Text = message;
            ErrorMessage.Visibility = Visibility.Visible;
        }


        // Upload Photo Button
        private void UploadPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png",
                Title = "Select Profile Picture"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new System.Uri(openFileDialog.FileName);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    ProfileImage.Source = bitmap;
                }
                catch
                {
                    MessageBox.Show("An error occurred while loading the image.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Preferences Button
        private void PreferenceButton_Click(object sender, RoutedEventArgs e)
        {
            var customMessageBox = new CustomMessageBox();
            if (customMessageBox.ShowDialog() == true)
            {
                string selectedOption1 = customMessageBox.SelectedOption1;
                string selectedOption2 = customMessageBox.SelectedOption2;

                if (!preferences.Contains(selectedOption1))
                {
                    MessageBox.Show($"You selected:\nOption 1: {selectedOption1}\nOption 2: {selectedOption2}",
                    "Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                    preferences.Add(selectedOption1);
                }
                else
                {
                    MessageBox.Show("This particular preference already exists. Consider removing it to edit this.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        // View Preferences Button
        private void ViewPreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            if (preferences.Count > 0)
            {
                string preferencesText = string.Join("\n", preferences);
                MessageBox.Show($"Current Preferences:\n{preferencesText}", "Preferences", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No preferences added yet.", "No Preferences", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Preferences Button for adding preferences
        private void prefrenceButton_Click(object sender, RoutedEventArgs e)
        {
            var customMessageBox = new CustomMessageBox();
            if (customMessageBox.ShowDialog() == true)
            {
                string selectedOption1 = customMessageBox.SelectedOption1;
                string selectedOption2 = customMessageBox.SelectedOption2;

                if (!preferences.Contains(selectedOption1))
                {
                    MessageBox.Show($"You selected:\nOption 1: {selectedOption1}\nOption 2: {selectedOption2}",
                    "Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                    preferences.Add(selectedOption1);
                }
                else
                {
                    MessageBox.Show("This particular preference already exists. Consider removing it to edit this.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
