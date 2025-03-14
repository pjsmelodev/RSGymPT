using RSGymPT.Services;
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
            while (true)
            {
                Console.Clear();

                if (AuthService.LoggedUser != null)
                {
                    Helpers.PrintTitle($"RSGymPT - Request Menu - {AuthService.LoggedUser.UserName}");
                }
                else
                {
                    Helpers.PrintTitle("RSGymPT - Request Menu");
                }
                Console.WriteLine();
                Console.WriteLine("1. Register a new request");
                Console.WriteLine("2. Alter a request");
                Console.WriteLine("3. Delete a request");
                Console.WriteLine("4. List all requests");
                Console.WriteLine("5. Set a request as complete");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterRequestFlow();
                        break;
                    case "2":
                        ModifyRequestFlow();
                        break;
                    case "3":
                        DeleteRequestFlow();
                        break;
                    case "4":
                        ListRequestsFlow();
                        break;
                    case "5":
                        CompleteRequestFlow();
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

        //<summary>
        //Handles the flow for registering a request.
        //</summary>
        private static void RegisterRequestFlow()
        {
            Console.Clear();
            try
            {
                Console.Write("Enter the personal trainer code: ");
                string ptCode = Console.ReadLine();

                Console.Write("Enter the scheduled date and time (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime scheduleDate))
                {
                    Console.WriteLine("\nInvalid date format.");
                    return;
                }

                var request = RequestService.RegisterRequest(AuthService.LoggedUser.UserCode, ptCode, scheduleDate);
                Console.WriteLine($"\nRequest registered successfully with ID: {request.RequestId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            Helpers.PauseConsole();
        }

        //<summary>
        //Handles the flow for modifying a request.
        //</summary>
        private static void ModifyRequestFlow()
        {
            Console.Clear();
            try
            {
                Console.Write("Enter the request ID to modify: ");
                if (!int.TryParse(Console.ReadLine(), out int requestId))
                {
                    Console.WriteLine("\nInvalid request ID.");
                    return;
                }

                Console.Write("Enter the new scheduled date and time (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime newScheduleDate))
                {
                    Console.WriteLine("\nInvalid date format.");
                    return;
                }

                if (RequestService.ModifyRequest(requestId, newScheduleDate))
                {
                    Console.WriteLine("\nRequest modified successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            Helpers.PauseConsole();
        }

        //<summary>
        //Handles the flow for deleting a request.
        //</summary>
        private static void DeleteRequestFlow()
        {
            Console.Clear();
            try
            {
                Console.Write("Enter the request ID to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int requestId))
                {
                    Console.WriteLine("\nInvalid request ID.");
                    return;
                }

                if (RequestService.DeleteRequest(requestId))
                {
                    Console.WriteLine("\nRequest deleted successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            Helpers.PauseConsole();
        }

        //<summary>
        //Handles the flow for listing all requests of the logged-in user.
        //</summary>
        private static void ListRequestsFlow()
        {
            Console.Clear();
            var requests = RequestService.GetUserRequests(AuthService.LoggedUser.UserCode);

            if (requests.Any())
            {
                Console.WriteLine("\nYour Requests:");
                foreach (var request in requests)
                {
                    Console.WriteLine($"ID: {request.RequestId} | PT Code: {request.PTCode} | Date: {request.ScheduleDate:yyyy-MM-dd HH:mm} | Status: {request.Status}");
                }
            }
            else
            {
                Console.WriteLine("\nNo requests found.");
            }
            Helpers.PauseConsole();
        }

        //<summary>
        //Handles the flow for completing a request.
        //</summary>
        private static void CompleteRequestFlow()
        {
            Console.Clear();
            try
            {
                Console.Write("Enter the request ID to complete: ");
                if (!int.TryParse(Console.ReadLine(), out int requestId))
                {
                    Console.WriteLine("\nInvalid request ID.");
                    return;
                }

                if (RequestService.CompleteRequest(requestId))
                {
                    Console.WriteLine("\nRequest set to completed successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            Helpers.PauseConsole();
        }
    }
}
