using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SmartParkingSystem.Core.Models;
using SmartParkingSystem.Services;


namespace SmartParkingSystem.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ParkingLotManager parkingLotManager;

        public MainWindow()
        {
            InitializeComponent();
            // Инициализация менеджера парковки с количеством мест
            parkingLotManager = new ParkingLotManager(10);
        }

        // Метод для парковки автомобиля
        private void ParkButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем номер парковочного места и тип транспорта
            if (int.TryParse(ParkingSpotTextBox.Text, out int spotNumber) && VehicleTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string vehicleType = selectedItem.Content.ToString();
                Vehicle vehicle = CreateVehicle(vehicleType);

                if (vehicle != null && parkingLotManager.Park(vehicle))
                {
                    MessageBox.Show("Vehicle parked successfully.");
                    UpdateParkingStatus();
                }
                else
                {
                    MessageBox.Show("Parking failed.");
                }
            }
        }

        // Метод для освобождения парковки
        private void ReleaseButton_Click(object sender, RoutedEventArgs e)
        {
            string plateNumber = PlateNumberTextBox.Text;

            var cost = parkingLotManager.Release(plateNumber);
            if (cost > 0)
            {
                MessageBox.Show($"Vehicle released. Total cost: {cost:C}");
                UpdateParkingStatus();
            }
            else
            {
                MessageBox.Show("Vehicle not found.");
            }
        }

        // Создание автомобиля в зависимости от типа
        private Vehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Car":
                    return new Car();
                case "Motorcycle":
                    return new Motorcycle();
                case "Electric Car":
                    return new ElectricCar();
                default:
                    return null;
            }
        }

        // Обновление состояния парковки
        private void UpdateParkingStatus()
        {
            OccupiedSpotsListBox.Items.Clear();
            foreach (var vehicle in parkingLotManager.GetAllParkedVehicles())
            {
                OccupiedSpotsListBox.Items.Add(vehicle.PlateNumber);
            }

            AvailableSpotsTextBlock.Text = $"Available spots: {parkingLotManager.GetFreeSpotsCount()}";
            RevenueTextBlock.Text = $"Total revenue: {parkingLotManager.GetTotalRevenue():C}";
        }
    }
}