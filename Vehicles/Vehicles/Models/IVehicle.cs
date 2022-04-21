using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Enums;

namespace Vehicles.Models
{
    public interface IVehicle
    {
        public double MinSpeed { get; set; }
        public double MaxSpeed { get; set; }

        public SpeedUnit SpeedUnit { get; set; }

        public double CurrentSpeed { get; set; }

        public bool IsStarted { get; }

        public VehicleState State { get; set; }

        public Movement Enviroment { get; set; }

        public void Start();

        public void Stop();

        public void Accelerate(double accelerateValue);

        public void Decelerate(double decelerateValue);


    }
}
