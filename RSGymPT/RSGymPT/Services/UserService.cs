using RSGymPT.Models;
using RSGymPT.Data;

namespace RSGymPT.Services
{
    //<summary>
    //This class contains the methods to manage users.
    //</summary>
    public class UserService
    {
        //<summary>
        //Lists all users without displaying their passwords.
        //</summary>
        public static List<User> ListUserNoPass()
        {
            return SeedData.Users
                .Select(user => new User
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    BirthDate = user.BirthDate,
                    UserCode = user.UserCode
                })
                .ToList();
        }
    }
}
