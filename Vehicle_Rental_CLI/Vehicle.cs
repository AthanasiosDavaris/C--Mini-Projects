using System;

namespace RentalCompany
{
    // type of fuel
    public enum FuelType
    {
        Petrol,
        Diesel,
        Electric
    }

    // vehicle
    public abstract class Vehicle
    {
        // Properties
        // license plate number
        public string? LicensePlateNumber { get; set; }

        // number of passengers
        public int NumberOfPassengers { get; set; }

        // type of fuel
        public FuelType Fuel { get; set; }

        // displacement
        public int Displacement { get; set; }

        // Methods
        // carries
        public void Carries()
        {
            Console.WriteLine($"The vehicle with license plate {LicensePlateNumber} carries {NumberOfPassengers} passengers.");
        }

        // calculate prices
        public abstract decimal CalculateDailyRentalPrice();
    }

    // car
    public class Car : Vehicle
    {
        public override decimal CalculateDailyRentalPrice()
        {
            decimal basePrice = 40.0m;
            decimal displacementCost = Displacement * 0.02m;

            decimal fuelSurcharge = 0m;
            if (Fuel == FuelType.Diesel) fuelSurcharge = 5.0m;
            else if (Fuel == FuelType.Electric) fuelSurcharge = 10.0m;

            return basePrice + displacementCost + fuelSurcharge;
        }
    }

    // motorcycle
    public class Motorcycle : Vehicle
    {
        public override decimal CalculateDailyRentalPrice()
        {
            decimal basePrice = 15.0m;
            decimal displacementCost = Displacement * 0.01m;

            decimal fuelSurcharge = 0m;
            if (Fuel == FuelType.Electric) fuelSurcharge = 3.0m;

            return basePrice + displacementCost + fuelSurcharge;
        }
    }
}