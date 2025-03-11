using RSGymPT.Utils;
using RSGymPT.UI;

namespace RSGymPT
{
    //<summary>
    //This class contains the main method.
    //</summary>
    class Program
    {
        //<summary>
        //This is the main method.
        //</summary>
        //<param name="args">The arguments passed to the application (not used).</param>
        static void Main(string[] args)
        {
            //LoginMenu.ShowLoginMenu();
            MainMenu.ShowMainMenu();
            Helpers.PauseConsole();
        }
    }
}