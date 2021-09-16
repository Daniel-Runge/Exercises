using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public abstract class ParkingRateCalculator
    {
        public int PricePerMinute { get; set; }
        public abstract int CalculateParkingPrice(int timeInMinutes);
    }

    public class WeekendParkingRateCalculator : ParkingRateCalculator
    {
        public WeekendParkingRateCalculator()
        {
            PricePerMinute = 5;
        }

        public override int CalculateParkingPrice(int timeInMinutes)
        {
            return timeInMinutes * PricePerMinute;
        }

    }

    public class WeekdayParkingRateCalculator : ParkingRateCalculator
    {
        public WeekdayParkingRateCalculator()
        {
            PricePerMinute = 1;
        }
        public override int CalculateParkingPrice(int timeInMinutes)
        {
            return timeInMinutes * PricePerMinute;
        }
    }
}
