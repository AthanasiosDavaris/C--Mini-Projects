using System;

namespace RentalCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create new car object and set properties
            Car myCar = new Car();
            myCar.LicensePlateNumber = "ABC-1234";
            myCar.NumberOfPassengers = 5;
            myCar.Fuel = FuelType.Diesel;
            myCar.Displacement = 2000;

            // Create new motorcycle object and set properties
            Motorcycle myBike = new Motorcycle();
            myBike.LicensePlateNumber = "MOTO-999";
            myBike.NumberOfPassengers = 2;
            myBike.Fuel = FuelType.Petrol;
            myBike.Displacement = 600;

            // Test "Carries" method
            Console.WriteLine("--- Passenger Information ---");
            myCar.Carries();
            myBike.Carries();

            // Test "CalculateDailyRentalPrice" method
            Console.WriteLine("\n--- Daily Rental Prices ---");

            decimal carPrice = myCar.CalculateDailyRentalPrice();
            Console.WriteLine($"The car ({myCar.LicensePlateNumber}) costs ${carPrice} per day.");

            decimal bikePrice = myBike.CalculateDailyRentalPrice();
            Console.WriteLine($"The motorcycle ({myBike.LicensePlateNumber}) costs ${bikePrice} per day.");

            Console.ReadLine();
        }
    }
}