namespace RSGymPT.Utils
{
    //<summary>
    //Utility class for common functions.
    //</summary>
    class Utilities
    {
        //<summary>
        //Pauses the terminal untill a key is pressed.
        //This is useful to prevent the console from closing immediately.
        //</summary>
        public static void PauseTerminal()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        //<summary>
        //Prints a formated title to the console.
        //</summary>
        //<param name="title">The title to be printed.</param>
        public static void PrintTitle(string title)
        {
            int lineLength = title.Length;

            // TODO: não sei se vou ter de tirar esta linha
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('=', lineLength));
            Console.WriteLine(title.ToUpper());
            Console.WriteLine(new string('=', lineLength));
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
