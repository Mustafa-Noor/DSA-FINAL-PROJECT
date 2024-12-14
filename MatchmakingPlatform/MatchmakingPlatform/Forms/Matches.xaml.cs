using System.Windows;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.Forms
{
    public partial class Matches : Window
    {
        Female female;
        public Matches(Female female)
        {
            InitializeComponent();
        }
        public List<Male> GetMales()
        {
            return null;
        }
    }
}
