using System.Windows.Media.Imaging;
namespace MatchmakingPlatform.BL
{
    public class Male
    {
        public string UserName{ get; set;}
        public string Password { get; set;}
        public string FirstName{ get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address {get; set;}
        public string City {get; set;}
        public string Profession {get; set;}
        public double Height { get; set;  }
        public string Education { get; set; }
        public double Salary { get; set; }
        public BitmapImage Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set;}

        public Male(string UserName, string Password, string Email, string ContactNumber, DateTime DateOfBirth, string Gender){
            this.UserName = UserName;
            this.FirstName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.ContactNumber  = ContactNumber;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
        }
       public bool CheckPassword(string password)
       {
            if(Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
