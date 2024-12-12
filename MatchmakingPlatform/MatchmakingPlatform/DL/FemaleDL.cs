using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.DL
{
    class FemaleDL
    {
        static Dictionary<string, Female> Females = new Dictionary<string, Female>();

        static public bool AddUser(Female user)
        {
            if (Females.ContainsKey(user.Username))
            {
                return false; // User already exists
            }

            Females[user.Username] = user;
            return true;
        }

        static public bool CheckUserExists(string username)
        {
            if (Females.ContainsKey(username))
            {
                return true;
            }

            return false;
        }

        static public Female FindUser(string username)
        {
            if (Females.ContainsKey(username))
            {
                return Females[username];
            }

            return null;
        }
    }
}
