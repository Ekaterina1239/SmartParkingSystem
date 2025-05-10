using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingSystem.Core.Models
{
    public class ParkingSpot
    {
        public int SpotNumber { get; set; }
        public Vehicle? Vehicle { get; set; }

        public bool IsOccupied => Vehicle != null;
    }
}
