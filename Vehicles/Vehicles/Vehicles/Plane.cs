using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Vehicles
{
    public class Plane : AirVehicle
    {
        public Motor VehicleMotor { get; set; }
        public Plane(Motor motor) : base()
        {
            VehicleMotor = motor;
        }
    }
}
