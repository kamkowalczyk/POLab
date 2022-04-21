using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Enums;

namespace Vehicles.Models
{
    public abstract class VehicleBase : IVehicle
    {
        double _currentSpeed = 0;

        Movement _enviroment;
        public double MinSpeed { get; set; }
        public double MaxSpeed { get; set; }

        public SpeedUnit SpeedUnit { get; set; }

        public double CurrentSpeed
        {
            get { return _currentSpeed; }
            set
            {

                if (!IsStarted)
                {
                    Console.WriteLine("Pojazd nie jest uruchomiony!");
                    return;
                }

                if (value < 0) _currentSpeed = 0;
                else if (value < MinSpeed) _currentSpeed = MinSpeed;
                else if (value > MaxSpeed) _currentSpeed = MaxSpeed;
                else _currentSpeed = value;

            }
        }

        public bool IsStarted => State == VehicleState.start;

        public VehicleState State { get; set; }


        public Movement Enviroment
        {
            get => _enviroment;
            set
            {
                _enviroment = value;

                OnEnviromentChanged();
            }
        }

        public VehicleBase()
        {
            State = VehicleState.stop;
        }


        public void Start()
        {
            if (IsStarted) throw new ArgumentOutOfRangeException("Pojazd już się porusza.");

            Console.WriteLine($"Pojazd startowy: { this.GetType()}");
            this.State = VehicleState.start;
            this.CurrentSpeed = this.MinSpeed;
        }

        public void Stop()
        {
            if (!IsStarted) throw new ArgumentOutOfRangeException("Vehicle is stopped");

            Console.WriteLine($"Zatrzymywanie pojazdu: { this.GetType()}");

            this.State = VehicleState.stop;
            this.CurrentSpeed = 0;
        }

        public void Accelerate(double accelerateValue)
        {
            if (!IsStarted)
            {
                Console.WriteLine("Pojazd nie jest uruchomiony!");
            }
            else
            {
                this.CurrentSpeed += accelerateValue;
                Console.WriteLine($"Przyspieszenie prędkości pojazdu przez: {accelerateValue}, aktualna prędkość to { CurrentSpeed}{SpeedUnit}");
            }

        }

        public void Decelerate(double decelerateValue)
        {
            if (!IsStarted)
            {
                Console.WriteLine("Pojazd nie jest uruchomiony!");

            }
            else
            {
                this.CurrentSpeed -= decelerateValue;
                Console.WriteLine($"Zmniejszam prędkość pojazdu o: {decelerateValue}, aktualna prędkość wynosi: {CurrentSpeed}{SpeedUnit}");
            }

        }

        public void OnEnviromentChanged()
        {
            switch (Enviroment)
            {
                case Movement.water:
                    MinSpeed = 1;
                    MaxSpeed = 40;
                    SpeedUnit = SpeedUnit.nmi;
                    return;
                case Movement.ground:
                    MinSpeed = 1;
                    MaxSpeed = 350;
                    SpeedUnit = SpeedUnit.kmph;
                    return;
                case Movement.air:
                    MinSpeed = 20;
                    MaxSpeed = 200;
                    SpeedUnit = SpeedUnit.mps;
                    return;
                default:
                    MinSpeed = 0;
                    MaxSpeed = 0;
                    SpeedUnit = SpeedUnit.kmph;
                    return;
            }
        }


        public string ToString()
        {
            return
                $"Aktualne środowisko: {Enviroment} \n " +
                $"Stan: {IsStarted} \n " +
                $"Minimalna szybkość: {MinSpeed} \n " +
                $"Maksymalna szybkość: {MaxSpeed} \n " +
                $"Aktualna szybkość: {CurrentSpeed} \n ";
        }



    }
}
