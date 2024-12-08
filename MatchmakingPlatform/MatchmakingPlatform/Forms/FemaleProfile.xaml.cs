using MatchmakingPlatform.Extras;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MatchmakingPlatform.Forms
{
    public partial class FemaleProfile : Window
    {
        HashSet<string> prefrences = new HashSet<string>();
        public FemaleProfile()
        {
            InitializeComponent();
        }

        // Flag to track edit state
        private bool isEditing = false;

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
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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
            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(ContactNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(CityTextBox.Text) ||
                StatusComboBox.SelectedIndex == -1 || // Ensure status is selected
                string.IsNullOrWhiteSpace(HeightTextBox.Text) || // Ensure height is provided
                EducationComboBox.SelectedIndex == -1) // Ensure education is selected
            {
                return false;
            }

            // Validate height field (only numeric and positive)
            if (!double.TryParse(HeightTextBox.Text, out double height) || height <= 0)
            {
                MessageBox.Show("Please enter a valid height.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
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
