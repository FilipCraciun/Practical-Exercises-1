using System;
using VehicleManagement.Interfaces;

namespace VehicleManagement.Models;

public class Car : Vehicle, IDriveable
{
    public int NumberOfDoors { get; set; }

    public override void StartEngine()
    {
        Console.WriteLine("The car engine starts with a key.");
    }

    public void Drive()
    {
        Console.WriteLine("The car is driving on the road.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Doors: {NumberOfDoors}";
    }
}
