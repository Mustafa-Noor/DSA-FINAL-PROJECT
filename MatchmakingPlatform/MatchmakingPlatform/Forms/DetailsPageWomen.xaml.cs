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

namespace MatchmakingPlatform.Forms
{
    /// <summary>
    /// Interaction logic for DetailsPageWomen.xaml
    /// </summary>
    public partial class DetailsPageWomen : Window
    {
        public Female CurrentUser { get; set; }
        public DetailsPageWomen(Female female)
        {
            CurrentUser = female;
            InitializeComponent();

            DataContext = CurrentUser;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
