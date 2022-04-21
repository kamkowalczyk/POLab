using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class OilMotor : Motor
    {
        public OilMotor(int horsePower) : base(Enums.Fuel.oil, horsePower) { }
    }
}
