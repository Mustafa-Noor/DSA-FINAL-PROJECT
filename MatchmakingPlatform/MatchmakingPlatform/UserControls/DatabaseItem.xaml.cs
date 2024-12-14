using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MatchmakingPlatform.UserControls
{

public partial class DatabaseItem : UserControl
{
            public DatabaseItem()
            {
                InitializeComponent();
            ToolTip toolTip = new ToolTip
            {
                Content = "This is a picture tooltip."
            };

            // Assign the tooltip to the Ellipse
            ToolTipService.SetToolTip(PictureEllipse, toolTip);
        }

            private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
            {
                ActionButton.Visibility = Visibility.Visible;
            }

            private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
            {
                ActionButton.Visibility = Visibility.Collapsed;
            }
        }
    }


    