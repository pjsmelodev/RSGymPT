namespace RSGymPT.Utils
{
    //<summary>
    //This class contains helper methods that are used throughout the application.
    //</summary>
    public class Helpers
    {
        //<summary>
        //This method pauses the console until a key is pressed.
        //</summary>
        public static void PauseConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        //<summary>
        //This method prints a formated title to the console.
        //</summary>
        //<param name="title">The title to be printed.</param>
        public static void PrintTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('=', title.Length + 4));
            Console.WriteLine($"| {title.ToUpper()} |");
            Console.WriteLine(new string('=', title.Length + 4));
            Console.ResetColor();
        }

        //<summary>
        //This method securely reads a password from the console, replacing characters with '*'.
        //</summary>
        //<returns>The password entered by the user.</returns>
        public static string HidePassword()
        {
            string password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b"); 
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine(); 
            return password;
        }
    }
}
