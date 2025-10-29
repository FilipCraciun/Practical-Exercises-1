using System;

namespace VehicleManagement.Models;

public class Vehicle
{
    public string Brand { get; set; } = " ";
    public string Model { get; set; } = " ";
    public int Year { get; set; }

    //Overriden by derived classes
    public virtual void StartEngine()
    {
        Console.WriteLine("The vehicle engine starts.");
    }

    //Helps in displaying vehicle details
    public override string ToString()
    {
        return $"{GetType().Name}: {Brand} {Model} ({Year})";
    }
}
