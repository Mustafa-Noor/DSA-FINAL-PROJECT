using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchmakingPlatform.BL
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string phoneNumber { get; set; }

        public User(string username, string password, string email, string gender, DateTime dateofBirth, string phoneNumber) 
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateofBirth;
            this.phoneNumber = phoneNumber;

        }

    }
}
