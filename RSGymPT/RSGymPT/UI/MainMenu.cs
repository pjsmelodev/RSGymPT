using RSGymPT.Utils;
using RSGymPT.Services;

namespace RSGymPT.UI
{
    //<summary>
    //This class contains the methods to display the main menu.
    //</summary>
    public class MainMenu
    {
        //<summary>
        //This method displays the main menu.
        //</summary>
        public static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();

                if (AuthService.LoggedUser != null)
                {
                    Helpers.PrintTitle($"RSGymPT - Main Menu - {AuthService.LoggedUser.UserName}");
                }
                else
                {
                    Helpers.PrintTitle("RSGymPT - Main Menu");
                }
                Console.WriteLine();
                Console.WriteLine("1. Request");
                Console.WriteLine("2. Personal Trainer");
                Console.WriteLine("3. User");
                Console.WriteLine("0. Exit");
                Console.Write("Chose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        RequestMenu.ShowRequestMenu();
                        break;
                    case "2":
                        Console.Clear();
                        PTMenu.ShowPTMenu();
                        break;
                    case "3":
                        Console.Clear();
                        UserMenu.ShowUserMenu();
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
