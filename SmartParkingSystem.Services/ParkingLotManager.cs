using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParkingSystem.Core.Models;


namespace SmartParkingSystem.Services
{
    public class ParkingLotManager
    {
        public List<ParkingSpot> Spots { get; private set; }

        public ParkingLotManager(int capacity)
        {
            Spots = new List<ParkingSpot>();
            for (int i = 1; i <= capacity; i++)
            {
                Spots.Add(new ParkingSpot { SpotNumber = i });
            }
        }

        // Метод для парковки автомобиля
        public bool Park(Vehicle vehicle)
        {
            var spot = Spots.FirstOrDefault(s => !s.IsOccupied);
            if (spot == null)
            {
                return false; // Нет свободных мест
            }

            vehicle.EntryTime = DateTime.Now;
            spot.Vehicle = vehicle;
            return true;
        }

        // Метод для освобождения парковочного места
        public decimal Release(string plateNumber)
        {
            var spot = Spots.FirstOrDefault(s => s.Vehicle?.PlateNumber == plateNumber);
            if (spot == null || spot.Vehicle == null)
            {
                return 0m; // Если нет автомобиля с таким номером
            }

            var vehicle = spot.Vehicle;
            var duration = DateTime.Now - vehicle.EntryTime;
            var cost = (decimal)duration.TotalHours * vehicle.GetHourlyRate();
            spot.Vehicle = null; // Освобождаем парковку
            return Math.Round(cost, 2);
        }

        // Метод для получения всех припаркованных автомобилей
        public List<Vehicle> GetAllParkedVehicles()
        {
            return Spots.Where(s => s.IsOccupied).Select(s => s.Vehicle).ToList();
        }

        // Метод для получения количества свободных парковочных мест
        public int GetFreeSpotsCount()
        {
            return Spots.Count(s => !s.IsOccupied);
        }
        public decimal GetTotalRevenue()
        {
            decimal totalRevenue = 0m;

            foreach (var spot in Spots)
            {
                if (spot.IsOccupied && spot.Vehicle != null)
                {
                    var vehicle = spot.Vehicle;
                    var duration = DateTime.Now - vehicle.EntryTime;
                    totalRevenue += (decimal)duration.TotalHours * vehicle.GetHourlyRate();
                }
            }

            return totalRevenue;
        }
    }
}
