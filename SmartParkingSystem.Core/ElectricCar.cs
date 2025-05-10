using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingSystem.Core.Models
{
    public class ElectricCar : Vehicle
    {
        public override decimal GetHourlyRate() => 0.0m;
    }
}
