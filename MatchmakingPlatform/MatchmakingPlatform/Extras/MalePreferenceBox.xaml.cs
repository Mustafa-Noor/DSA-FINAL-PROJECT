using System.Windows;
using System.Windows.Automation;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.Extras{

    public partial class MalePreferenceBox : Window {
        public string prefrence {get;private set;}

        public int value {get; private set;}
        public string condition {get;private set;}

        Male male;
        public MalePreferenceBox(Male male)
        {
           
            InitializeComponent();
            this.male = male;
            // Populate ComboBoxes (example data)

            ComboBox1.ItemsSource = new[] { "Age", "Height","Education","Profession","Monthly Income"};
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            prefrence = ComboBox1.SelectedItem?.ToString();
            condition = ComboBox2.SelectedItem?.ToString();
            float value = float.NaN;
            string prefText = PrefrenceText.Text;
            if (string.IsNullOrEmpty(prefrence) || string.IsNullOrEmpty(condition))
            {
                MessageBox.Show("Please select both options before proceeding.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidatePreference())
            {
                return;
            }


            if (ComboBox1.SelectedItem.ToString() == "Age" || ComboBox1.SelectedItem.ToString() == "Height" || ComboBox1.SelectedItem.ToString() == "Monthly Income")
            {
                value = float.Parse(prefText);
            }

            if (male.DoesPreferenceExist(prefrence))
            {
                MessageBox.Show("This preference already is selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }



                
            Preference pref = new Preference(prefrence,value,condition);
            male.Preferences.Add(pref);
            male.Queue.Enqueue(pref);
            //int size = male.Queue.Size();
            //MessageBox.Show($"The size of the queue is: {size}", "Queue Size", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            ShowSuccessMessage("Preference value Added.");
            Close();

        }

        private bool ValidatePreference()
        {
            string selectedPreference = ComboBox1.SelectedItem.ToString();
            string preferenceText = PrefrenceText.Text;
            //if (string.IsNullOrEmpty(preferenceText))
            //{
            //    MessageBox.Show("Preference value cannot be empty. For current preference", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return false;
            //}

            bool isValid = true;
            if (selectedPreference == "Age")
            {
                //isValid = Validations.ValidateAge(preferenceText);
                isValid = Validations.ValidateWithCondition(preferenceText, condition, 18, 100);
            }
            else if (selectedPreference == "Height")
            {
                //isValid = Validations.ValidateHeight(preferenceText);
                isValid = Validations.ValidateWithCondition(preferenceText, condition, 100, 200);
            }
            else if (selectedPreference == "Monthly Income")
            {
                isValid = Validations.ValidateWithCondition(preferenceText, condition, 0, int.MaxValue);
            }


            if (!isValid)
            {
                ShowErrorMessage("Invalid value for the selected preference.");
                return false;
            }
            else
            {
                // Proceed with further processing
                
                return true;
            }
        }


        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Validation Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ComboBox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if(ComboBox1.SelectedItem.ToString()=="Age"|| ComboBox1.SelectedItem.ToString()=="Height"||ComboBox1.SelectedItem.ToString()=="Monthly Income"){
                ComboBox2.ItemsSource = new[] {"Less Than","Equal to","Greater than"};
                PrefrenceText.IsEnabled = true;
            }else if (ComboBox1.SelectedItem.ToString() == "Profession") {
                ComboBox2.ItemsSource = new[] {"Business","Private Employee","Government Employee","Free Lancer"};
                PrefrenceText.IsEnabled = false;
            }else if(ComboBox1.SelectedItem.ToString() == "Education"){
                ComboBox2.ItemsSource = new[] {"Matric","Inter","Diploma","Bacholer","Master","Doctorate"};
                PrefrenceText.IsEnabled = false;
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}