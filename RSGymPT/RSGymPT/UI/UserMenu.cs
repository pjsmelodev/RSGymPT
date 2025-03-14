using RSGymPT.Services;
using RSGymPT.Utils;

namespace RSGymPT.UI
{
    //<summary>
    //This class contains the methods to display the user menu.
    //</summary>
    public class UserMenu
    {
        //<summary>
        //This method displays the user menu.
        //</summary>
        public static void ShowUserMenu()
        {
            while (true)
            {
                Console.Clear();


                if (AuthService.LoggedUser != null)
                {
                    Helpers.PrintTitle($"RSGymPT - User Menu - {AuthService.LoggedUser.UserName}");
                }
                else
                {
                    Helpers.PrintTitle("RSGymPT - User Menu");
                }
                Console.WriteLine();
                Console.WriteLine("1. List all users");
                Console.WriteLine("0. Exit");
                Console.Write("Chose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        var users = UserService.ListUserNoPass();

                        if (users.Any())
                        {
                            Console.WriteLine("Registered Users:");
                            foreach (var user in users)
                            {
                                Console.WriteLine($"ID: {user.UserId} | Name: {user.UserName} | Birthdate: {user.BirthDate:yyyy-MM-dd} | Code: {user.UserCode}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo users found.");
                        }
                        Console.WriteLine();
                        Helpers.PauseConsole();
                        break;
                    case "0":
                        Console.WriteLine("\nExiting...");
                        Helpers.PauseConsole();
                        LoginMenu.ShowLoginMenu();
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Try again.");
                        Helpers.PauseConsole();
                        break;
                }
            }
        }
    }
}
