using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingSystem.Core.Models
{
    public abstract class Vehicle
    {
        public string PlateNumber { get; set; } = string.Empty;
        public DateTime EntryTime { get; set; }

        public abstract decimal GetHourlyRate();
    }
}
