using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int STAMINA = 6;
        public NaturalClimber(string name) 
            : base(name, STAMINA)
        {
        }

        public override void Rest(int daysCount)
        {
            base.Stamina += 2 * daysCount;
        }
    }
}
