using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic;

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
        public string Image { get; set; }
        public int Age { get; set; }
        public ObservableCollection<Preference> Preferences { get; set; }

        public string FullImagePath
        {
            get
            {
                return Utils.Utility.FilePath + Image; // Concatenate FilePath with Image path
            }
        }

        //public PreferenceQueue Queue {get; set;}
        public Queue<Preference> Queue { get; set; }

        public Female(string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender){ 
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            Preferences = new ObservableCollection<Preference>();
            Age = (DateAndTime.Now.Year - DateOfBirth.Year);
            Queue = new Queue<Preference>();
        }

        public Female()
        {
            Preferences = new ObservableCollection<Preference>();
            Queue = new Queue<Preference>();
        }
        public bool CheckPassword(string password){ return Password == password;}


        public bool DoesPreferenceExist(string preferenceName)
        {

            if (Preferences == null || Preferences.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < Preferences.Count; i++)
            {
                if (Preferences[i].Pref == preferenceName)
                {
                    return true;
                }
            }

            return false;
        }


        public void clearPreferences()
        {
            Preferences.Clear();
            Queue.Clear();
        }
    }


}