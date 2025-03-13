using RSGymPT.Models;
using RSGymPT.Data;

namespace RSGymPT.Services
{
    //<summary>
    //This class contains the methods for the authentication service.
    //</summary>
    public class AuthService
    {
        private static User? loggedUser;

        public static User? LoggedUser => loggedUser;

        //<summary>
        //Validates the login credentials and logs in the user if valid.
        //</summary>
        //<param name="username">The username to be validated.</param>
        //<param name="password">The password to be validated.</param>
        public static bool Login(string username, string password)
        {
            var user = SeedData.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                loggedUser = user;
                return true;
            }

            return false;
        }

        //<summary>
        //Logs out the currently logged in user.
        //</summary>
        public static void Logout()
        {
            loggedUser = null;
        }
    }
}
