using System.Windows.Media.Imaging;

namespace MatchmakingPlatform.BL
{
    public class Female
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set;}
        public string firstName {  get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public float height { get; set; }
        public string status { get; set; }
        public string education { get; set; }
        public BitmapImage Image { get; set; }

        public Female(string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender){ 
            firstName = username;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
        }

        public bool CheckPassword(string password){ return Password == password;}
    }
}