using System;
using Vehicles.Models;
using Vehicles.Vehicles;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCar();
            TestPlane();
            TestShip();
            TestAmphibian();
        }


        private static void TestCar()
        {

            Motor motor = new Motor(Enums.Fuel.petrol, 150);
            Car car = new Car(motor);

            Console.WriteLine("Car:");
            car.Start();
            car.Accelerate(130);
            car.Decelerate(20);
            Console.WriteLine(car.ToString());
            car.Stop();


        }

        private static void TestPlane()
        {
            Motor motor = new Motor(Enums.Fuel.petrol, 650);
            Plane plane = new Plane(motor);

            Console.WriteLine("Plane:");
            plane.Start();
            plane.Accelerate(20);
            Console.WriteLine(plane.ToString());
            plane.TakeOff();
            plane.Stop();
            Console.WriteLine(plane.ToString());

            plane.Accelerate(100);
            plane.Decelerate(20);
            plane.Land();
            plane.Stop();
        }

        private static void TestShip()
        {
            OilMotor motor = new OilMotor(550);
            Ship ship = new Ship(340, motor);

            Console.WriteLine("Ship:");
            ship.Start();
            ship.Accelerate(10);
            ship.Decelerate(5);
            Console.WriteLine(ship.ToString());

            ship.Stop();
        }

        private static void TestAmphibian()
        {
            OilMotor motor = new OilMotor(650);
            Amphibian amphibian = new Amphibian(500, 4, motor);

            Console.WriteLine("Amphibian:");
            amphibian.Start();
            amphibian.Accelerate(30);
            Console.WriteLine(amphibian.ToString());

            amphibian.GetIntoWater();
            amphibian.Accelerate(10);
            Console.WriteLine(amphibian.ToString());

            amphibian.Decelerate(5);
            amphibian.GetOntoGround();
            Console.WriteLine(amphibian.ToString());

            amphibian.Stop();




        }


    }
}
