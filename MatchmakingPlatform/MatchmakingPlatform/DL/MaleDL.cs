using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.DL
{
    class MaleDL
    {
        static Dictionary<string, Male> Males = new Dictionary<string, Male>();

        static public bool AddUser(Male user)
        {
            if (Males.ContainsKey(user.Username))
            {
                return false; // User already exists
            }

            Males[user.Username] = user;
            return true;
        }

        static public bool CheckUserExists(string username)
        {
            if (Males.ContainsKey(username))
            {
                return true;
            }

            return false;
        }

        static public Male FindUser(string username)
        {
            if (Males.ContainsKey(username))
            {
                return Males[username];
            }

            return null;
        }
    }
}
