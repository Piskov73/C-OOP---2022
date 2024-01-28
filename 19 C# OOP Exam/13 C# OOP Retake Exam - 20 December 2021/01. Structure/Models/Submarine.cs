using NavalVessels.Models.Contracts;
using System;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double BaseArmorThickness = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, BaseArmorThickness)
        {
            this.submergeMode = false;
        }

        public bool SubmergeMode => this.submergeMode;

        public override void RepairVessel()
        {
            base.ArmorThickness = BaseArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            this.submergeMode = !this.submergeMode;
            if (SubmergeMode)
            {
                base.MainWeaponCaliber += 40;
                base.Speed -= 4;
            }
            else
            {
                base.MainWeaponCaliber -= 40;
                base.Speed += 4;
            }
        }


        public override string ToString()
        {
            string mode = SubmergeMode ? "ON" : "OFF";
            return base.ToString()+Environment.NewLine+ $" *Submerge mode: {mode}";
        }
    }
}
