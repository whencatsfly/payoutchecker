using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLinesTest.Results;
using WinLinesTest.Utils;

namespace WinLinesTest.Request
{
    public class BonusRequest : Client
    {
        public BonusRequest(Form1 form) : base(form)
        {

        }
        public void BRequest(String bonusKey, int bonusId)
        {
            Form1 dataGrid = new Form1();

            String bonusParams = "";
            var bonusCompleted = false;
            String bonusType = "";
            int counter = 1;
            String bonusValue;
            int type = Convert.ToInt32(Configurations.GameType);
            do
            {

                switch (type)
                {
                    case 0: //cascading
                        bonusValue = "0";
                        bonusParams = $"game={Configurations.gameName}&key={Configurations.TokenKey}" +
                    $"&bonus={bonusValue}&param={bonusValue}&&ts={Configurations.TimeStamp}&platform=web";

                        break;

                    case 1:

                        var param = counter.ToString();
                        var mode = counter.ToString();

                        if (bonusId == 3 || bonusId == 4)
                        {
                            counter++;

                        }

                        bonusParams = $"game={Configurations.gameName}&key={Configurations.TokenKey}" +
                      $"&bonus={Configurations.TokenKey}&param={param}&mode={mode}&ts={Configurations.TimeStamp}&platform=web";
                        break;

                    case 2:
                        bonusParams = $"game={Configurations.gameName}&key={Configurations.TokenKey}" +
                      $"&bonus={Configurations.TokenKey}&param=0&&ts={Configurations.TimeStamp}&platform=web";

                        break;
                }

                var actualResult = SlotRequest<BonusResult>(Configurations.BonusEndpoint, bonusParams);
                Console.WriteLine("Bonus Ongoing");

                bonusCompleted = actualResult.BonusCompleted;
                bonusType = actualResult.Type;

                if (bonusType == "fs" || bonusType == "cs")
                {
                    int winCOunt = actualResult.BonusNum.WinPositions.Length;

                    for (int count = 0; count < winCOunt; count++)
                    {


                        Double computedPayouts = new double();

                        Configurations.Count = Convert.ToInt32(actualResult.BonusNum.WinPositions[count].Count);
                        Configurations.Symbol = Convert.ToInt32(actualResult.BonusNum.WinPositions[count].Symbol);
                        Configurations.WildMultiplier = Convert.ToInt32(actualResult.BonusNum.WinPositions[count].WildMultiplier);
                        Configurations.Multiplier = Convert.ToDouble(actualResult.BonusNum.WinPositions[count].Multiplier);
                        Configurations.WinAmount = Convert.ToDouble(actualResult.BonusNum.WinPositions[count].Win);
                        Configurations.TotalBet = Convert.ToDouble(actualResult.TotalBet);

                        String oddsSymbol = Configurations.Symbol.ToString() + "x" + Configurations.Count.ToString();

                        ComputePayout compute = new ComputePayout();
                        computedPayouts = compute.ComputePayouts(oddsSymbol, Configurations.Symbol, Configurations.Count, Configurations.WildMultiplier,
                            Configurations.TotalBet, Convert.ToDouble(Configurations.Bet));

                        if (Configurations.WinAmount == computedPayouts)
                        {
                            Configurations.linesData[oddsSymbol].Pass = true;
                        }
                        UpdateDataSource.Update(form.dataGridView1);
                    }
                }

            } while (!bonusCompleted);

        }
    }
}
