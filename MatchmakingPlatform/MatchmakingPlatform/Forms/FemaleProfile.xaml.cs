using MatchmakingPlatform.Extras;
using System.Windows;
using System.Windows.Media.Imaging;
using MatchmakingPlatform.BL;
using MatchmakingPlatform.DL;   

namespace MatchmakingPlatform.Forms
{
    public partial class FemaleProfile : Window
    {
        HashSet<string> prefrences = new HashSet<string>();
        private Female currentFemale;
        public FemaleProfile(Female female)
        {
            currentFemale = female;
            InitializeComponent();
            PopulateFields();
        }

        // Flag to track edit state
        private bool isEditing = false;


        private void PopulateFields()
        {
            if (currentFemale != null)
            {
                FirstNameTextBox.Text = currentFemale.firstName;
                LastNameTextBox.Text = currentFemale.lastName;
                EmailTextBox.Text = currentFemale.Email;
                ContactNumberTextBox.Text = currentFemale.PhoneNumber;
                AddressTextBox.Text = currentFemale.address;
                CityTextBox.Text = currentFemale.city;
                StatusComboBox.Text = currentFemale.status;
                HeightTextBox.Text = currentFemale.height.ToString();
                EducationComboBox.Text = currentFemale.education;

                if (currentFemale.Image != null)
                {
                    try
                    {
                        ProfileImage.Source = currentFemale.Image;  // Assign directly
                    }
                    catch
                    {
                        MessageBox.Show("Failed to load profile image.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }
        }
        // Edit Info Button
        private void EditInfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                // Enable all input fields
                FirstNameTextBox.IsEnabled = true;
                LastNameTextBox.IsEnabled = true;
                EmailTextBox.IsEnabled = true;
                ContactNumberTextBox.IsEnabled = true;
                AddressTextBox.IsEnabled = true;
                CityTextBox.IsEnabled = true;
                StatusComboBox.IsEnabled = true;
                HeightTextBox.IsEnabled = true;
                EducationComboBox.IsEnabled = true;

                // Change button text to "Cancel Edit"
                (sender as System.Windows.Controls.Button).Content = "Cancel Edit";
                isEditing = true;
            }
            else
            {
                // Disable all input fields and reset button text
                DisableFields();
                (sender as System.Windows.Controls.Button).Content = "Edit Info";
                isEditing = false;
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

            currentFemale.firstName = FirstNameTextBox.Text;
            currentFemale.lastName = LastNameTextBox.Text;
            currentFemale.Email = EmailTextBox.Text;
            currentFemale.PhoneNumber = ContactNumberTextBox.Text;
            currentFemale.address = AddressTextBox.Text;
            currentFemale.city = CityTextBox.Text;
            currentFemale.status = StatusComboBox.Text;
            currentFemale.height = float.Parse(HeightTextBox.Text);
            currentFemale.education = EducationComboBox.Text;

            // Logic to save the user information (e.g., save to database)
            MessageBox.Show("Profile information saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Disable fields after saving
            DisableFields();
            isEditing = false;
        }

        // Cancel Button
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                // Reset the fields to their original state
                ResetFields();
                DisableFields();

                // Reset Edit Info button
                var editButton = LogicalTreeHelper.FindLogicalNode(this, "EditInfoButton") as System.Windows.Controls.Button;
                if (editButton != null)
                {
                    editButton.Content = "Edit Info";
                }

                isEditing = false;
            }
            else
            {
                // Close the window
                this.Close();
            }
        }

        // Helper to Disable Fields
        private void DisableFields()
        {
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            EmailTextBox.IsEnabled = false;
            ContactNumberTextBox.IsEnabled = false;
            AddressTextBox.IsEnabled = false;
            CityTextBox.IsEnabled = false;
            StatusComboBox.IsEnabled = false;
            HeightTextBox.IsEnabled = false;
            EducationComboBox.IsEnabled = false;
        }

        // Helper to Reset Fields (if Cancel is pressed)
        private void ResetFields()
        {
            // Reset fields to default or previously saved values
            FirstNameTextBox.Text = ""; // Replace with the original value if available
            LastNameTextBox.Text = "";
            EmailTextBox.Text = "";
            ContactNumberTextBox.Text = "";
            AddressTextBox.Text = "";
            CityTextBox.Text = "";
            StatusComboBox.SelectedIndex = -1; // Reset ComboBox selection
            HeightTextBox.Text = "";
            EducationComboBox.SelectedIndex = -1; // Reset ComboBox selection
        }

        // Validation Function
        private bool ValidateFields()
        {
            if (isEditing)
            {
                ErrorMessageTextBlock.Visibility = Visibility.Collapsed;

                // Validate first name
                if (Validations.CheckforEmpty(FirstNameTextBox.Text) || Validations.CheckingForSpace(FirstNameTextBox.Text))
                {
                    ErrorMessageTextBlock.Text = "First Name cannot be empty or contain spaces.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate last name
                if (Validations.CheckforEmpty(LastNameTextBox.Text) || Validations.CheckingForSpace(LastNameTextBox.Text))
                {
                    ErrorMessageTextBlock.Text = "Last Name cannot be empty or contain spaces.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate email
                if (Validations.CheckforEmpty(EmailTextBox.Text) || !Validations.ValidateEmailPattern(EmailTextBox.Text))
                {
                    ErrorMessageTextBlock.Text = "Email should be in the proper format.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate contact number
                if (Validations.CheckforEmpty(ContactNumberTextBox.Text) || !Validations.ValidateContactPattern(ContactNumberTextBox.Text))
                {
                    ErrorMessageTextBlock.Text = "Phone Number should be in the correct format.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate address
                if (Validations.CheckforEmpty(AddressTextBox.Text))
                {
                    ErrorMessageTextBlock.Text = "Address cannot be empty.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate city
                if (Validations.CheckforEmpty(CityTextBox.Text))
                {
                    ErrorMessageTextBlock.Text = "City cannot be empty.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate status selection
                if (StatusComboBox.SelectedIndex == -1)
                {
                    ErrorMessageTextBlock.Text = "Please select a status.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate height
                if (Validations.CheckforEmpty(HeightTextBox.Text) || !double.TryParse(HeightTextBox.Text, out double height) || height <= 0)
                {
                    ErrorMessageTextBlock.Text = "Please enter a valid height.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate education selection
                if (EducationComboBox.SelectedIndex == -1)
                {
                    ErrorMessageTextBlock.Text = "Please select your education.";
                    ErrorMessageTextBlock.Visibility = Visibility.Visible;
                    return false;
                }

                // Validation passed
                return true;
            }

            return false;
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

        private void prefrenceButton_Click(object sender, RoutedEventArgs e)
        {
            var customMessageBox = new CustomMessageBox();
            if (customMessageBox.ShowDialog() == true)
            {
                string selectedOption1 = customMessageBox.SelectedOption1;
                string selectedOption2 = customMessageBox.SelectedOption2;

                if (!prefrences.Contains(selectedOption1))
                {
                    MessageBox.Show($"You selected:\nOption 1: {selectedOption1}\nOption 2: {selectedOption2}",
                    "Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                    prefrences.Add(selectedOption1);
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
            if (prefrences.Count > 0)
            {
                string preferences = string.Join("\n", prefrences);
                MessageBox.Show($"Current Preferences:\n{preferences}", "Preferences", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No preferences added yet.", "No Preferences", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
