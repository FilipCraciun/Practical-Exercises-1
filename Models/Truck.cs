using System;
using VehicleManagement.Interfaces;

namespace VehicleManagement.Models;

public class Truck : Vehicle, IDriveable
{
    public double CargoCapacity { get; set; } // in tons

    public override void StartEngine()
    {
        Console.WriteLine("The truck engine rumbles to life.");
    }

    public void Drive()
    {
        Console.WriteLine("The truck is hauling goods.");
    }

    public override string ToString()
    {
        return base.ToString() + $" | Capacity: {CargoCapacity} tons";
    }
}

