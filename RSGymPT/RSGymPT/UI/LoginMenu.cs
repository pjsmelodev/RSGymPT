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

                if (AuthService.LoggedUser != null)
                {
                    Helpers.PrintTitle($"RSGymPT - Login Menu - {AuthService.LoggedUser.UserName}");
                }
                else
                {
                    Helpers.PrintTitle("RSGymPT - Login Menu");
                }

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
                            Console.WriteLine($"\nWelcome, {AuthService.LoggedUser?.UserName}!");
                            Helpers.PauseConsole();
                            MainMenu.ShowMainMenu();
                            failedAttempts = 0;
                        }
                        else
                        {
                            failedAttempts++;
                            int attemptsLeft = MaxAttempts - failedAttempts;
                            Console.WriteLine($"\nInvalid credentials.\n{attemptsLeft} attempts left.");
                            Helpers.PauseConsole();

                            if (failedAttempts >= MaxAttempts)
                            {
                                Console.WriteLine("\nToo many failed attempts. Access blocked");
                                Helpers.PauseConsole();
                                Environment.Exit(0);
                            }
                        }
                        break;
                    case "0":
                        Console.WriteLine("\nExiting...");
                        Helpers.PauseConsole(); 
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Try again.");
                        Helpers.PauseConsole();
                        break;
                }
            }
        }
    }
}
