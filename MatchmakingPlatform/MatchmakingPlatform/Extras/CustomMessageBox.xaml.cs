using System.Windows;
using System.Windows.Controls;

namespace MatchmakingPlatform.Extras{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window {
        public string SelectedOption1 { get; private set; }
        public string SelectedOption2 { get; private set; }

        public CustomMessageBox()
        {
            InitializeComponent();

            // Populate ComboBoxes (example data)
            ComboBox1.ItemsSource = new[] { "Age", "Height", "Martial Status","Education","Profession","Profession","Monthly Income"};
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedOption2 = ComboBox2.SelectedItem?.ToString();
            SelectedOption1 = ComboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(SelectedOption1) || string.IsNullOrEmpty(SelectedOption2))
            {
                MessageBox.Show("Please select both options before proceeding.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
            Close();
        }
        private void ComboBox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if(ComboBox1.SelectedItem.ToString()=="Age"|| ComboBox1.SelectedItem.ToString()=="Height"||ComboBox1.SelectedItem.ToString()=="Monthly Income"){
                ComboBox2.ItemsSource = new[] {"Less Than","Equal to","Greater than"};
                PrefrenceText.IsEnabled = true;
            }else if(ComboBox1.SelectedItem.ToString()=="Martial Status") {
                ComboBox2.ItemsSource = new[] {"Single","Married","Divorced","Widowed"};
                PrefrenceText.IsEnabled = false;
            }else if (ComboBox1.SelectedItem.ToString() == "Profession") {
                ComboBox2.ItemsSource = new[] {"Business","Private Employee","Government Employee","Free Lancer"};
                PrefrenceText.IsEnabled = false;
            }else if(ComboBox1.SelectedItem.ToString() == "Education"){
                ComboBox2.ItemsSource = new[] {"Matric","Inter","Diploma","Bacholer","Master","Doctorate"};
                PrefrenceText.IsEnabled = false;
            }
        }
    }
}