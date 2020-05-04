using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLinesTest.Utils
{
    public class ComputePayout
    {
        public double ComputePayouts(String oddSymbols, int Symbol, int count, int wildMultiplier, double TotalBet, double bet)
        {
            Double payout = new double();
            //String oddSymbol = Symbol.ToString() + "x" + count.ToString();
            int odds = Convert.ToInt32(Configurations.linesData[oddSymbols].Win);
            //int odds = Convert.ToInt32(Configurations.linesData.ContainsKey(oddSymbols));
            double multiplier = Convert.ToDouble(Configurations.multiplier);
            int scatterSymbol = Convert.ToInt32(Configurations.linesData["scatter"].Win);

            if (wildMultiplier == 0)
            {
                if(Symbol == scatterSymbol)
                {
                    payout = (TotalBet * odds  * multiplier);
                }
                else
                {
                    payout = (bet * odds * multiplier );
                }
            }
            else
            {
                if (Symbol == scatterSymbol)
                {
                    payout = (TotalBet * odds * wildMultiplier);
                }
                else
                {
                    payout = (bet * odds * wildMultiplier);
                }
            }
            return Math.Round(payout,2);
        }
    }
}
