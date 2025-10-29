using System;
using VehicleManagement.Interfaces;

namespace VehicleManagement.Models;

public class Motorcycle : Vehicle, IDriveable
{
    public bool HasSidecar { get; set; }

    public override void StartEngine()
    {
        Console.WriteLine("The motorcycle engine starts with a button.");
    }

    public void Drive()
    {
        Console.WriteLine("The motorcycle is cruising on the road.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Sidecar: {(HasSidecar ? "Yes" : "No")}";
    }
}

