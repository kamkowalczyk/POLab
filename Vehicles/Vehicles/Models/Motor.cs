using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Enums;

namespace Vehicles.Models
{
    public class Motor
    {
        public Fuel MotorFuel { get; protected set; }
        public int HorsePower { get; protected set; }

        public Motor(Fuel fuel, int horsePower)
        {
            MotorFuel = fuel;
            HorsePower = horsePower;
        }
    }
}
