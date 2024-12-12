using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace MatchmakingPlatform.BL
{
    public class Male:UserRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Profession { get; set; }
        public double Height { get; set; }
        public string Education { get; set; }
        public double Salary { get; set; }
        public BitmapImage Image { get; set; }

        public Male(string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender) : base(username, password, email, phoneNumber, dateOfBirth, gender) { }







    }

}
