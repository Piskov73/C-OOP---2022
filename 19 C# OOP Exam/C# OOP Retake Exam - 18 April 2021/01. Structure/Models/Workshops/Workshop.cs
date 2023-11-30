using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy>0&&bunny.Dyes.Any(d=>d.IsFinished()==false)&&egg.IsDone()==false)
            {
              var dye=bunny.Dyes.First(d=>!d.IsFinished());
                while (!dye.IsFinished()&&bunny.Energy>0&&!egg.IsDone())
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();
                }
            }
        }
    }
}
