using MatchmakingPlatform.Extras;
using System.Windows;
using System.Windows.Media.Imaging;
using MatchmakingPlatform.BL;
using MatchmakingPlatform.DL;   

namespace MatchmakingPlatform.Forms
{
    public partial class FemaleProfile : Window
    {
        private Female currentFemale;
        public FemaleProfile(Female female)
        {
            currentFemale = female;
            InitializeComponent();
            PopulateFields();
            WindowState = WindowState.Maximized;
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

                if(currentFemale.Image != null)
                {
                    try
                    {
                        ProfileImage.Source = currentFemale.Image;
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
            if(!isEditing) {
                EnableFields();
                EditInfoButton.Content = "Cancel Edit";
                CancelButton.Content = "Clear";
                isEditing = true;
            }
            else
            {
                DisableFields();
                EditInfoButton.Content = "Edit Info";
                CancelButton.Content = "Next";
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

            if(!isEditing)
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

                /*var editButton = LogicalTreeHelper.FindLogicalNode(this, "EditInfoButton") as System.Windows.Controls.Button;
                if (editButton != null)
                {
                    editButton.Content = "Edit Info";
                }*/

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


        private void EnableFields()
        {
            FirstNameTextBox.IsEnabled = true;
            LastNameTextBox.IsEnabled = true;
            EmailTextBox.IsEnabled = true;
            ContactNumberTextBox.IsEnabled = true;
            AddressTextBox.IsEnabled = true;
            CityTextBox.IsEnabled = true;
            StatusComboBox.IsEnabled = true;
            HeightTextBox.IsEnabled = true;
            EducationComboBox.IsEnabled = true;
        }

        private void ResetFields()
        {
            // Reset fields to default or previously saved values
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            EmailTextBox.Text = "";
            ContactNumberTextBox.Text = "";
            AddressTextBox.Text = "";
            CityTextBox.Text = "";
            StatusComboBox.SelectedIndex = -1;
            HeightTextBox.Text = "";
            EducationComboBox.SelectedIndex = -1;
        }

        // Validation Function
        private bool ValidateFields()
        {
            if (isEditing)
            {
                ErrorMessage.Visibility = Visibility.Collapsed;

                // Validate first name
                if (Validations.CheckforEmpty(FirstNameTextBox.Text) || Validations.CheckingForSpace(FirstNameTextBox.Text))
                {
                    ErrorMessage.Text = "First Name cannot be empty or contain spaces.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate last name
                if (Validations.CheckforEmpty(LastNameTextBox.Text) || Validations.CheckingForSpace(LastNameTextBox.Text))
                {
                    ErrorMessage.Text = "Last Name cannot be empty or contain spaces.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate email
                if (Validations.CheckforEmpty(EmailTextBox.Text) || !Validations.ValidateEmailPattern(EmailTextBox.Text))
                {
                    ErrorMessage.Text = "Email should be in the proper format.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate contact number
                if (Validations.CheckforEmpty(ContactNumberTextBox.Text) || !Validations.ValidateContactPattern(ContactNumberTextBox.Text))
                {
                    ErrorMessage.Text = "Phone Number should be in the correct format.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate address
                if (Validations.CheckforEmpty(AddressTextBox.Text))
                {
                    ErrorMessage.Text = "Address cannot be empty.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate city
                if (Validations.CheckforEmpty(CityTextBox.Text))
                {
                    ErrorMessage.Text = "City cannot be empty.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate status selection
                if (StatusComboBox.SelectedIndex == -1)
                {
                    ErrorMessage.Text = "Please select a status.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }

                // Validate height
                if (Validations.CheckforEmpty(HeightTextBox.Text) || !double.TryParse(HeightTextBox.Text, out double height) || height <= 0)
                {
                    ErrorMessage.Text = "Please enter a valid height.";
                    ErrorMessage.Visibility = Visibility.Visible;
                    return false;
                }
                // Validate education selection
                if (EducationComboBox.SelectedIndex == -1)
                {
                    ErrorMessage.Text = "Please select your education.";
                    ErrorMessage.Visibility = Visibility.Visible;
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
    }
}
