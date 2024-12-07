using MatchmakingPlatform.BL;

namespace MatchmakingPlatform.DL
{
    class UserRegistrationDL
    {
        static Dictionary<string, UserRegistration> Users = new Dictionary<string, UserRegistration>();

        static public bool AddUser(UserRegistration user)
        {
            if (Users.ContainsKey(user.Username))
            {
                return false; // User already exists
            }

            Users[user.Username] = user; 
            return true;
        }

        static public bool CheckUserExists(string username)
        {
            if (Users.ContainsKey(username))
            {
                return true;
            }

            return false;
        }

        static public UserRegistration FindUser(string username)
        {
            if (Users.ContainsKey(username))
            {
                return Users[username];
            }

            return null;
        }


  

    }
}
