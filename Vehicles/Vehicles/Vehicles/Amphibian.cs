using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Vehicles
{
    public class Amphibian : VehicleBase
    {
        public int Displacement { get; }
        public int WheelsCount { get; }

        public Motor VehicleMotor;

        public Amphibian(int displacement, int wheelsCount, OilMotor motor) : base()
        {
            Displacement = displacement;
            WheelsCount = wheelsCount;
            Enviroment = Enums.Movement.ground;
            VehicleMotor = motor;
        }


        public void GetIntoWater()
        {
            Enviroment = Enums.Movement.water;
        }

        public void GetOntoGround()
        {
            Enviroment = Enums.Movement.ground;
        }


    }
}
