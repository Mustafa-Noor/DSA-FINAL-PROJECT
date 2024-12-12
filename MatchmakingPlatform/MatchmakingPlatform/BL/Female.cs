using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MatchmakingPlatform.BL
{
    public class Female:UserRegistration
    {
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public float height { get; set; }
        public string status { get; set; }
        public string education { get; set; }
        public BitmapImage Image { get; set; }

        public Female(string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender): base(username, password, email, phoneNumber, dateOfBirth, gender) { 

        }

    }
}
