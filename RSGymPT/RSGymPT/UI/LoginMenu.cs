using RSGymPT.Utils;

namespace RSGymPT.UI
{
    public class LoginMenu
    {
        public static void ShowLoginMenu()
        {
            bool exitMenu = false;

            while (!exitMenu)
            {
                Helpers.PrintTitle("RSGymPT - Login Menu");
                Console.WriteLine();
                Console.WriteLine("1. Login");
                Console.WriteLine("0. Exit");
                Console.Write("Chose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        // TODO: implementar logica
                        Helpers.PauseConsole();
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again. [1, 2]");
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
