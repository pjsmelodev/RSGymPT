using RSGymPT.Utils;

namespace RSGymPT.UI
{
    //<summary>
    //This class contains the methods to display the request menu.
    //</summary>
    public class RequestMenu
    {
        //<summary>
        //This method displays the request menu.
        //</summary>
        public static void ShowRequestMenu()
        {
            bool exitMenu = false;

            while (!exitMenu)
            {
                Helpers.PrintTitle("RSGymPT - Request Menu");
                Console.WriteLine();
                Console.WriteLine("1. Register a new request");
                Console.WriteLine("2. Alter a request");
                Console.WriteLine("3. Delete a request");
                Console.WriteLine("4. List all requests");
                Console.WriteLine("5. Set a request as complete");
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
                    case "3":
                        Console.Clear();
                        // TODO: implementar logica
                        Helpers.PauseConsole();
                        break;
                    case "4":
                        Console.Clear();
                        // TODO: implementar logica
                        Helpers.PauseConsole();
                        break;
                    case "5":
                        Console.Clear();
                        // TODO: implementar logica
                        Helpers.PauseConsole();
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        exitMenu = true;
                        Helpers.PauseConsole();
                        // TODO: voltar para o main menu
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
