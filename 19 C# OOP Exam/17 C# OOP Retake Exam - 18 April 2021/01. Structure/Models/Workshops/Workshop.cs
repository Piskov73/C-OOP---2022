using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy == 0 && !bunny.Dyes.Any(x => x.IsFinished() == false))
            {
                return;
            }
            foreach (var dye in bunny.Dyes)
            {
                while (!egg.IsDone()&&!dye.IsFinished())
                {
                    egg.GetColored();
                    dye.Use();
                    bunny.Work();
                    if (bunny.Energy == 0 || egg.IsDone())
                        return;
                }
            }
        }
    }
}
