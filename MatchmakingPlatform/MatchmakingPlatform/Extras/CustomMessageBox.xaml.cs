using System.Windows;

namespace MatchmakingPlatform.Extras {
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
            ComboBox1.ItemsSource = new[] { "Option 1A", "Option 1B", "Option 1C" };
            ComboBox2.ItemsSource = new[] { "Option 2A", "Option 2B", "Option 2C" };
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedOption1 = ComboBox1.SelectedItem?.ToString();
            SelectedOption2 = ComboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(SelectedOption1) || string.IsNullOrEmpty(SelectedOption2))
            {
                MessageBox.Show("Please select both options before proceeding.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}