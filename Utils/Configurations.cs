using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinLinesTest.Utils.Enum;

namespace WinLinesTest.Utils
{
    public class Configurations
    {
        public static String SpinEndpoint = "";
        public static String BonusEndpoint = "";
        public static String GetBetsEndpoint = "";
        //Spin Request Parameters
        public static String gameName { get; set; }
        public static String TokenKey { get; set; }
        public static String Bet { get; set; }
        public static String TimeStamp { get; set; }
        public static int RunTimes { get; set; }
        public static String hasBonus = "";
        public static String multiplier { get; set; }
        public static String param { get; set; }
        public static String mode { get; set; }
        public static String GameType { get; set; }
        public static String BonusKey = "";
        public static String BonuCompleted = "";
        public static int currentTxn = 0;
        public static Dictionary<string, WinLine> linesData = new Dictionary<string, WinLine>();
        public static int CurrentProgress = 0;
        public static int Count = 0;
        public static double TotalBet = 0;
        public static int Symbol = 0;
        public static String Odds = "";
        public static int WildMultiplier = 0;
        public static double Multiplier = 0;
        public static double WinAmount = 0;
        //Client

        public Verbs Method
        {
            get;
            set;
        }
        public string ContentType
        {
            get;
            set;
        }
        public string PostData
        {
            get;
            set;
        }
    }
}
