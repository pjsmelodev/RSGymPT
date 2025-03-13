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
                        Console.Write("Enter the personal trainer code: ");
                        string code = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(code))
                        {
                            Console.WriteLine("\nError: The personal trainer code cannot be null or empty.");
                        }
                        else
                        {
                            var pt = Services.PersonalTrainerService.SearchPTByCode(code);
                            if (pt != null)
                            {
                                Console.WriteLine($"\nPersonal Trainer Found:\nID: {pt.PTId}\nName: {pt.PTName}\nPhone: {pt.Phone}\nCode: {pt.PTCode}");
                            }
                            else
                            {
                                Console.WriteLine("\nNo personal trainer found with the provided code.");
                            }
                        }
                        Console.WriteLine();
                        Helpers.PauseConsole();
                        break;
                    case "2":
                        Console.Clear();
                        Services.PersonalTrainerService.ListPTs().ForEach(pt => Console.WriteLine($"\nID: {pt.PTId}\nName: {pt.PTName}\nPhone: {pt.Phone}\nCode: {pt.PTCode}"));
                        Console.WriteLine();
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
