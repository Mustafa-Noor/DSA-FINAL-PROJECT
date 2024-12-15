using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.Extras
{
    /// <summary>
    /// Interaction logic for FemalePreferenceBox.xaml
    /// </summary>
    public partial class FemalePreferenceBox : Window
    {

        public string prefrence { get; private set; }

        public int value { get; private set; }
        public string condition { get; private set; }

        Female female;

        public FemalePreferenceBox(Female female)
        {
            InitializeComponent();
            this.female = female;
            ComboBox1.ItemsSource = new[] { "Age", "Height", "Education", "Monthly Income", "Profession" };
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedItem.ToString() == "Age" || ComboBox1.SelectedItem.ToString() == "Height" || ComboBox1.SelectedItem.ToString()=="Monthly Income")
            {
                ComboBox2.ItemsSource = new[] { "Less Than", "Greater than" };
                PrefrenceText.IsEnabled = true;
            }
            else if(ComboBox1.SelectedItem.ToString() == "Profession")
            {
                ComboBox2.ItemsSource = new[] {"Business","Private Employee","Government Employee","Free Lancer"};
                PrefrenceText.IsEnabled = false;
            }
            else if (ComboBox1.SelectedItem.ToString() == "Education")
            {
                ComboBox2.ItemsSource = new[] { "Matric", "Inter", "Diploma", "Bachelor", "Master", "Doctorate" };
                PrefrenceText.IsEnabled = false;
            }
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


            if (ComboBox1.SelectedItem.ToString() == "Age" || ComboBox1.SelectedItem.ToString() == "Height" || ComboBox1.SelectedItem.ToString()=="Monthly Income")
            {
                value = float.Parse(prefText);
            }

            if (female.DoesPreferenceExist(prefrence))
            {
                MessageBox.Show("This preference already is selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }




            Preference pref = new Preference(prefrence, value, condition);
            female.Preferences.Add(pref);
            female.Queue.Enqueue(pref);
            
            DialogResult = true;
            ShowSuccessMessage("Preference value Added.");
            Close();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
                isValid = Validations.ValidateWithCondition(preferenceText ,18, 100);
            }
            else if (selectedPreference == "Height")
            {
                //isValid = Validations.ValidateHeight(preferenceText);
                isValid = Validations.ValidateWithCondition(preferenceText, 100, 200);
            }else if(selectedPreference == "Mothly Income") {
                isValid = Validations.ValidateWithCondition(preferenceText, 0, int.MaxValue);
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
    }
}
