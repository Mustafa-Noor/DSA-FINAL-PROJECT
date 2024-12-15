using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic;
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
        public string Image {  get; set;}
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set;}
        public int Age {get; set; }

        public ObservableCollection<Preference> Preferences { get; set; }

        public PreferenceQueue Queue { get; set; }

        public string FullImagePath
        {
            get
            {
                return Utils.Utility.FilePath + Image; // Concatenate FilePath with Image path
            }
        }



        public Male()
        {
            Preferences = new ObservableCollection<Preference>();
            Queue = new PreferenceQueue();
        }


        public Male(string UserName, string Password, string Email, string ContactNumber, DateTime DateOfBirth, string Gender){
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
            this.ContactNumber  = ContactNumber;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            Preferences = new ObservableCollection<Preference>();
            Queue = new PreferenceQueue();
            Age = (DateAndTime.Now.Year-DateOfBirth.Year);
        }
       public bool CheckPassword(string password)
       {
            if(Password == password)
            {
                return true;
            }
            return false;
        }

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
