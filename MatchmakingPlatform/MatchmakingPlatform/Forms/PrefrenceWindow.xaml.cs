using MatchmakingPlatform.Extras;
using System.Collections.ObjectModel;
using System.Windows;

namespace MatchmakingPlatform.Forms
{
    public partial class PrefrenceWindow : Window
    {
        // ObservableCollection to store preferences
     
        public PrefrenceWindow()
        {
            InitializeComponent();
            
        }

        // Add Preference Button Click
        private void AddPreferenceButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // Clear Preferences Button Click
        private void ClearPreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // Find Pairs Button Click
        private void FindPairsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Find pairs functionality not implemented yet!");
        }
    }

    // Model for PreferenceItem
    public class PreferenceItem
    {
    }
}

