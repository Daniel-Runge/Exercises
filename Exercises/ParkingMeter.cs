using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class ParkingMeter
    {
        public ParkingRateCalculator Calculator { get; set; }

        public ParkingMeter(ParkingRateCalculator calculator)
        {
            Calculator = calculator;
        }

        public int InsertCoins(int minutes, int coins)
        {
            return coins - Calculator.CalculateParkingPrice(minutes);
        }

    }
}
