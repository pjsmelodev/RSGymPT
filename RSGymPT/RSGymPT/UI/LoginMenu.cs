using RSGymPT.Utils;

namespace RSGymPT.UI
{
    //<summary>
    //This class contains the methods to display the login menu.
    //</summary>
    public class LoginMenu
    {
        //<summary>
        //This method displays the login menu.
        //</summary>
        public static void ShowLoginMenu()
        {
            while (true)
            {
                Console.Clear();

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
                        Helpers.PauseConsole(); 
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Helpers.PauseConsole();
                        break;
                }
            }
        }
    }
}
