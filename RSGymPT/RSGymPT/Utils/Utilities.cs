using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT.Utils
{
    //<summary>
    //Utility class for common functions.
    //</summary>
    class Utilities
    {
        //<summary>
        //Pauses the terminal untill a key is pressed.
        //</summary>
        public static void PauseTerminal()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }


    }
}
