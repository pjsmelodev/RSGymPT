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
                        // TODO: implementar logica
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        Helpers.PauseConsole();
                        LoginMenu.ShowLoginMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Helpers.PauseConsole();
                        break;
                }
            }
        }
    }
}
