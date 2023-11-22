using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const double armorThickness = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, armorThickness)
        {
        }

        public bool SonarMode=>sonarMode;

        public void ToggleSonarMode()
        {
            sonarMode= !sonarMode;
            if(SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            ArmorThickness = armorThickness;
        }
        public override string ToString()
        {
            string positionSonar = SonarMode ? "ON" : "OFF";
            return base.ToString()+ Environment.NewLine+ $" *Sonar mode: {positionSonar}";
        }
    }
}
