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
using MatchmakingPlatform.Extras;

namespace MatchmakingPlatform.Forms
{
    public partial class WindowPreferenceFemale : Window
    {
        Female female;
        public WindowPreferenceFemale(Female female)
        {
            
           // InitializeComponent();
            this.female = female;
            this.DataContext = this.female;
        }

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
            FemalePreferenceBox customMessageBox = new FemalePreferenceBox(female);
            customMessageBox.ShowDialog();
        }

        private void ClearPreferencesButton_Click_1(object sender, RoutedEventArgs e)
        {
            female.clearPreferences();
        }
    }
}
