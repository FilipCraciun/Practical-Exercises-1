using VehicleManagement.Models;
using VehicleManagement.Interfaces; 
using System.Globalization;

namespace VehicleManagement
{
    internal class Program
    {
        private static readonly List<Vehicle> Vehicles = new();
        private static void Main()
        {
            SampleData();

            StartEngineAndDrive(Vehicles);

            while (true)
            {
                Console.WriteLine("\n=== Vehicle Management System ===");
                Console.WriteLine("1) Add Car");
                Console.WriteLine("2) Add Motorcycle");
                Console.WriteLine("3) Add Truck");
                Console.WriteLine("4) List Vehicles");
                Console.WriteLine("5) Start all engines & Drive");
                Console.WriteLine("0) Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        AddMotorcycle();
                        break;
                    case "3":
                        AddTruck();
                        break;
                    case "4":
                        ListVehicles();
                        break;
                    case "5":
                        StartEngineAndDrive(Vehicles);
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static string PromptString(string label)
        {
            while (true)
            {
                Console.Write($"{label}: ");
                var value = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(value))
                    return value.Trim();

                Console.WriteLine("Please enter a non-empty value.");
            }
        }

        private static int PromptInt(string label)
        {
            while (true)
            {
                Console.Write($"{label}: ");
                var value = Console.ReadLine();
                if (int.TryParse(value, out var number))
                    return number;

                Console.WriteLine("Please enter a valid integer.");
            }
        }

        private static double PromptDouble(string label)
        {
            while (true)
            {
                Console.Write($"{label}: ");
                var value = Console.ReadLine();

                if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var number) ||
                    double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out number))
                {
                    return number;
                }

                Console.WriteLine("Please enter a valid number (e.g., 7.5).");
            }
        }

        private static bool PromptBool(string label)
        {
            while (true)
            {
                Console.Write($"{label}: ");
                var value = Console.ReadLine()?.Trim().ToLowerInvariant();

                if (value is "y" or "yes" or "true")
                    return true;
                if (value is "n" or "no" or "false")
                    return false;

                Console.WriteLine("Please answer y/n.");
            }
        }
        private static void AddCar()
        {
            Console.WriteLine("== Add Car == ");
            var brand = PromptString("Brand");
            var model = PromptString("Model");
            var year = PromptInt("Year");
            var doors = PromptInt("Number of Doors");

            var car = new Car
            {
                Brand = brand,
                Model = model,
                Year = year,
                NumberOfDoors = doors
            };

            Vehicles.Add(car);
            Console.WriteLine("Car added.");
        }

        private static void AddMotorcycle()
        {
            Console.WriteLine("== Add Motorcycle ==");
            var brand = PromptString("Brand");
            var model = PromptString("Model");
            var year = PromptInt("Year");
            var hasSideCar = PromptBool("Has sidecar (y/n)");

            var moto = new Motorcycle
            {
                Brand = brand,
                Model = model,
                Year = year,
                HasSideCar = hasSideCar
            };

            Vehicles.Add(moto);
            Console.WriteLine("Motorcycle added.");
        }

        private static void AddTruck()
        {
            Console.WriteLine("== Add Truck ==");
            var brand = PromptString("Brand");
            var model = PromptString("Model");
            var year = PromptInt("Year");
            var capacity = PromptDouble("Cargo capacity (tons, e.g., 7.5)");

            var truck = new Truck
            {
                Brand = brand,
                Model = model,
                Year = year,
                CargoCapacity = capacity
            };

            Vehicles.Add(truck);
            Console.WriteLine("Truck added.");
        }

        private static void ListVehicles()
        {
            Console.WriteLine("== Vehicles ==");
            if (Vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles yet. Add some from the menu.");
                return;
            }

            int index = 1;
            foreach (var v in Vehicles)
            {
                Console.WriteLine($"{index++}. {v}");
            }
        }

        private static void StartEngineAndDrive(List<Vehicle> vehicles)
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available to start/drive.");
                return;
            }

            Console.WriteLine("== StartEngine & Drive ==");
            foreach (var v in vehicles)
            {
                // Car/Motorcycle/Truck override decides the message.
                v.StartEngine();

                if (v is IDriveable driveable)
                {
                    driveable.Drive();
                }
            }
        }

        private static void SampleData()
        {
            Vehicles.Add(new Car { Brand = "Toyota", Model = "Corolla", Year = 2020, NumberOfDoors = 4 });
            Vehicles.Add(new Motorcycle { Brand = "Yamaha", Model = "MT-07", Year = 2022, HasSideCar = false });
            Vehicles.Add(new Truck { Brand = "Volvo", Model = "FH16", Year = 2019, CargoCapacity = 18.0 });
        }
    }
}