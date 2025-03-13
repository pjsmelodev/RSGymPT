using RSGymPT.Utils;
using RSGymPT.Services;

namespace RSGymPT.UI
{
    //<summary>
    //This class contains the methods to display the personal trainer menu.
    //</summary>
    public class PTMenu
    {
        public static void ShowPTMenu()
        {
            while (true)
            {
                Console.Clear();

                if (AuthService.LoggedUser != null)
                {
                    Helpers.PrintTitle($"RSGymPT - Personal Trainer Menu - {AuthService.LoggedUser.UserName}");
                }
                else
                {
                    Helpers.PrintTitle("RSGymPT - Personal Trainer Menu");
                }
                Console.WriteLine();
                Console.WriteLine("1. Search a personal trainer by code");
                Console.WriteLine("2. List all personal trainers");
                Console.WriteLine("0. Exit");
                Console.Write("Chose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        // TODO: implementar logica
                        Helpers.PauseConsole();
                        break;
                    case "2":
                        Console.Clear();
                        // TODO: implementar logica
                        Helpers.PauseConsole();
                        break;
                    case "0":
                        Console.WriteLine("\nExiting...");
                        Helpers.PauseConsole();
                        MainMenu.ShowMainMenu();
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
