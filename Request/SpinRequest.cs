using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLinesTest.Results;
using WinLinesTest.Utils;

namespace WinLinesTest.Request
{
    public class SpinRequest : Client
    {
        public SpinRequest(Form1 form) : base(form)
        {

        }
        public void SRequest(string parameters)
        {
            int i = 1;
            while (i <= Configurations.RunTimes)
            {
                form.progressBar1.Value = i;
                var actualResult = SlotRequest<SpinResult>(Configurations.SpinEndpoint, parameters);

                Console.WriteLine(i + " Spin Request" + Configurations.Bet);

                int winCOunt = actualResult.WinPosition.Length;

                for (int count = 0; count < winCOunt; count++){


                    Double computedPayouts = new double(); 

                    Configurations.Count =  Convert.ToInt32(actualResult.WinPosition[count].Count);
                    Configurations.Symbol = Convert.ToInt32(actualResult.WinPosition[count].Symbol);
                    Configurations.WildMultiplier = Convert.ToInt32(actualResult.WinPosition[count].WildMultiplier);
                    //Configurations.Multiplier = Convert.ToInt32(actualResult.WinPosition[count].Multiplier);
                    Configurations.WinAmount = Convert.ToDouble(actualResult.WinPosition[count].Win);
                    Configurations.TotalBet = Convert.ToDouble(actualResult.TotalBet);

                    String oddsSymbol = Configurations.Symbol.ToString() + "x" + Configurations.Count.ToString();

                    ComputePayout compute = new ComputePayout();
                    computedPayouts = compute.ComputePayouts(oddsSymbol, Configurations.Symbol, Configurations.Count, Configurations.WildMultiplier, 
                        Configurations.TotalBet, Convert.ToDouble(Configurations.Bet));

                    if(Configurations.WinAmount == computedPayouts)
                    {
                        Configurations.linesData[oddsSymbol].Pass = true;
                    }
                    
                    UpdateDataSource.Update(form.dataGridView1);

                    Console.WriteLine("Ongoing");

                }
               

                if (actualResult.hasBonus)
                {
                    int bonusId = Convert.ToInt32(actualResult.Bonus.BonusId);
                    Configurations.BonusKey = Configurations.TokenKey;
                    BonusRequest runBonus = new BonusRequest(form);
                    runBonus.BRequest(Configurations.BonusKey, bonusId);
                }
                i++;
                
            }
        }
    }
}
