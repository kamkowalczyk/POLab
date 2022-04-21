using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class GroundVehicle : VehicleBase
    {
        public int WheelsCount { get; }

        public GroundVehicle(int wheelsCount) : base()
        {
            WheelsCount = wheelsCount;
            Enviroment = Enums.Movement.ground;

        }

        public new virtual string ToString()
        {

            return $"Typ: Lądowy \n " +
                $"Ilość kół: {WheelsCount} \n " + base.ToString();
        }
    }
}
