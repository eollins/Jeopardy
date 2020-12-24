using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class Globals
    {
        public static int[] playerScores = new int[6] { 0, 0, 0, 0, 0, 0 };
        public static string[] playerNames = new string[6] { "Player One", "Player Two", "Player Three", "Player Four", "Player Five", "Player Six" };
        public static int currentValue = 0;
        public static int round = 0;
        public static bool customAmount = false;
        public static int awardStatus = 0; //0 for none, 1 for award, 2 for remove
        public static string answer = "";
        public static bool generate = false;
        public static int gameType = 0;
        public static string dailyDoubles = "";
        public static bool end = false;
        public static bool sound = false;
        public static bool reveal = false;
        public static bool clear = false;
        public static bool export = false;
        public static int[] flash = null;
        public static bool unlockButton = false;
        public static bool unlockState = false;
        public static int gameCode = 0;
    }
}
