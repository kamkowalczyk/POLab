using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class AirVehicle : VehicleBase
    {

        public AirVehicle() : base()
        {
            Enviroment = Enums.Movement.ground;

        }

        public void TakeOff()
        {
            Enviroment = Enums.Movement.air;
            Console.WriteLine("Pojazd startuje...");
        }

        public void Land()
        {
            Enviroment = Enums.Movement.ground;
            Console.WriteLine("Pojazd wylądował.");
        }

        public new virtual void Stop()
        {
            if (Enviroment == Enums.Movement.air)
            {
                Console.WriteLine("Musisz wylądować pojazdem, aby go zatrzymać.");
                return;
            }

            base.Stop();
        }

        public new virtual string ToString()
        {

            return $"Typ: Powietrzny \n " + base.ToString();
        }

    }
}
