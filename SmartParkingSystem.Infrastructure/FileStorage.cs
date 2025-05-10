using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParkingSystem.Core.Models;
using System.IO;


namespace SmartParkingSystem.Infrastructure
{
    public class FileStorage
    {
        private const string FilePath = "parking.txt";

        // Сохранение состояния парковки
        public void Save(List<ParkingSpot> spots)
        {
            try
            {
                using (var writer = new StreamWriter(FilePath))
                {
                    foreach (var spot in spots)
                    {
                        // Сохраняем информацию о парковке в строковом формате
                        if (spot.Vehicle != null)
                        {
                            writer.WriteLine($"{spot.SpotNumber}|{spot.Vehicle.PlateNumber}|{spot.Vehicle.EntryTime}|{spot.Vehicle.GetType().Name}");
                        }
                        else
                        {
                            writer.WriteLine($"{spot.SpotNumber}|empty");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        // Загрузка состояния парковки
        public List<ParkingSpot> Load()
        {
            try
            {
                var spots = new List<ParkingSpot>();
                if (!File.Exists(FilePath)) return spots;

                using (var reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        var spot = new ParkingSpot
                        {
                            SpotNumber = int.Parse(parts[0])
                        };

                        if (parts[1] != "empty")
                        {
                            Vehicle vehicle = parts[3] switch
                            {
                                "Car" => new Car { PlateNumber = parts[1], EntryTime = DateTime.Parse(parts[2]) },
                                "Motorcycle" => new Motorcycle { PlateNumber = parts[1], EntryTime = DateTime.Parse(parts[2]) },
                                "ElectricCar" => new ElectricCar { PlateNumber = parts[1], EntryTime = DateTime.Parse(parts[2]) },
                                _ => null
                            };
                            spot.Vehicle = vehicle;
                        }

                        spots.Add(spot);
                    }
                }
                return spots;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return new List<ParkingSpot>();
            }
        }
    }
}
