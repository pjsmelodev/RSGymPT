using RSGymPT.Utils;
using RSGymPT.Services;

namespace RSGymPT.UI
{
    //<summary>
    //This class contains the methods to display the login menu.
    //</summary>
    public class LoginMenu
    {
        private const int MaxAttempts = 3;

        //<summary>
        //This method displays the login menu.
        //</summary>
        public static void ShowLoginMenu()
        {
            int failedAttempts = 0;

            while (true)
            {
                Console.Clear();

                Helpers.PrintTitle("RSGymPT - Login Menu");
                Console.WriteLine();
                Console.WriteLine("1. Login");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("User name: ");
                        string userName = Console.ReadLine() ?? "";
                        Console.Write("Password: ");
                        string password = Console.ReadLine() ?? "";

                        if (AuthService.Login(userName, password))
                        {
                            Console.WriteLine($"Welcome, {AuthService.LoggedUser?.UserName}!");
                            Helpers.PauseConsole();
                            MainMenu.ShowMainMenu();
                            failedAttempts = 0;
                        }
                        else
                        {
                            failedAttempts++;
                            Console.WriteLine("Invalid credentials. Please try again.");
                            Helpers.PauseConsole();

                            if (failedAttempts >= MaxAttempts)
                            {
                                Console.WriteLine("Too many failed attempts. Access blocked");
                                Helpers.PauseConsole();
                                Environment.Exit(0);
                            }
                        }
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
