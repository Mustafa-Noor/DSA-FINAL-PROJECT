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

        static public bool CheckUserExists(UserRegistration user)
        {
            if (Users.ContainsKey(user.Username))
            {
                return true;
            }

            return false;
        }

    }
}
