using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models;

namespace Vehicles.Vehicles
{
    public class Ship : WaterVehicle
    {
        public Motor VehicleMotor { get; set; }
        public Ship(int displacement, OilMotor motor) : base(displacement)
        {
            VehicleMotor = motor;
        }

    }
}
