using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Vehicles
{
    public class Car : GroundVehicle
    {
        public Motor VehicleMotor { get; }
        public Car(Motor motor, int wheelsCount = 4) : base(wheelsCount: wheelsCount)
        {
            VehicleMotor = motor;
        }
    }
}
