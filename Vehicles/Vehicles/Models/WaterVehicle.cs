using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class WaterVehicle : VehicleBase
    {
        public int Displacement { get; }


        public WaterVehicle(int displacement) : base()
        {
            Enviroment = Enums.Movement.water;
            Displacement = displacement;

        }


        public new virtual string ToString()
        {

            return $"Typ: Wodny \n " +
                $"Wyporność: {Displacement} \n " + base.ToString();
        }




    }
}
