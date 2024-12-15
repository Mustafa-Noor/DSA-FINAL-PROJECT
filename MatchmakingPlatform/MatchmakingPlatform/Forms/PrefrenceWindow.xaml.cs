using MatchmakingPlatform.BL;
using MatchmakingPlatform.Extras;
using System.Collections.ObjectModel;
using System.Windows;

namespace MatchmakingPlatform.Forms
{
    public partial class PrefrenceWindow : Window
    {
        // ObservableCollection to store preferences

        Female female;
        public PrefrenceWindow(Female male)
        {
            InitializeComponent();
            this.female = male;
            this.DataContext = this.female;
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


        private void AddPreferenceButton_Click_1(object sender, RoutedEventArgs e)
        {
            MalePreferenceBox customMessageBox = new MalePreferenceBox(female);
            customMessageBox.ShowDialog();
        }

        private void ClearPreferencesButton_Click_1(object sender, RoutedEventArgs e)
        {
            female.clearPreferences();
        }
    }

    // Model for PreferenceItem
    public class PreferenceItem
    {
    }
}
