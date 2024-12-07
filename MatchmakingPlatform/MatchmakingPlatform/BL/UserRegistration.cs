using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingPlatform.BL
{
    class UserRegistration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public UserRegistration(string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;

        }

        public static bool CheckPassword(string password, UserRegistration user)
        {
            if(user.Password == password)
            {
                return true;
            }

            return false;
        }


        public override string ToString()
        {
            return $"Username: {Username}, Email: {Email}, Phone: {PhoneNumber}, Date of Birth: {DateOfBirth.ToShortDateString()}, Gender: {Gender}";
        }




    }
}
