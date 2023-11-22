using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const double armorThickness = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {

        }
        public bool SubmergeMode => submergeMode;
        public void ToggleSubmergeMode()
        {
            submergeMode = !submergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override void RepairVessel()
        {
            ArmorThickness = armorThickness;
        }
        public override string ToString()
        {
            string poisitionSubmerge = SubmergeMode ? "ON" : "OFF";
            return base.ToString()+Environment.NewLine+ $" *Submerge mode: {poisitionSubmerge}";
        }
    }
}
