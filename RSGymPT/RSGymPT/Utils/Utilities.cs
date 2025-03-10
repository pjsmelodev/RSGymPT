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


    }
}
