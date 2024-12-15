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
    /// <summary>
    /// Interaction logic for PreferenceWindowFemale.xaml
    /// </summary>
    public partial class PreferenceWindowFemale : Window
    {
        Female female;
        public PreferenceWindowFemale(Female female)
        {
            InitializeComponent();
            this.female = female;
            DataContext = this.female;

        }

        void AddPreferences_Click(object sender, RoutedEventArgs e)
        {
            MalePreferenceBox customMessageBox = new MalePreferenceBox(female);
            customMessageBox.ShowDialog();
        }

        private void ClearAllPreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            female.clearPreferences();
        }
    }
}
