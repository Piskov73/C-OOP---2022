using NavalVessels.Models.Contracts;
using System;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double BaseArmorThickness = 300;
        private bool sonarMode;
        
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, BaseArmorThickness)
        {
            this.sonarMode = false;
        }

        public bool SonarMode => this.sonarMode;

        public override void RepairVessel()
        {
           base.ArmorThickness = BaseArmorThickness;
        }

        public void ToggleSonarMode()
        {
           this.sonarMode=!this.sonarMode;
            if(SonarMode)
            {
                base.MainWeaponCaliber += 40;
                base.Speed -= 5;
            }
            else
            {
                base.MainWeaponCaliber -= 40;
                base.Speed += 5;
            }
            
        }
        public override string ToString()
        {
            string sonar = SonarMode ? "ON" : "OFF";

            return base.ToString()+Environment.NewLine+ $" *Sonar mode: {sonar}";
        }
    }
}
