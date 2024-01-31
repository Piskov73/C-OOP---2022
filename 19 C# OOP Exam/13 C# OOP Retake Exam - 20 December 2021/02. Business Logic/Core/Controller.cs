using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        //        •	vessels - VesselRepository
        //•	captains - a collection of ICaptain

        private VesselRepository vessels;
        private HashSet<ICaptain> capitans;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.capitans = new HashSet<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            var capitan = this.capitans.FirstOrDefault(n => n.FullName == fullName);

            if (capitan != null)
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            capitan = new Captain(fullName);

            this.capitans.Add(capitan);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var vessel = this.vessels.FindByName(name);

            if (vessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            this.vessels.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel,vesselType,name,mainWeaponCaliber,speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var capitan=this.capitans.FirstOrDefault(n=>n.FullName==selectedCaptainName);

            if(capitan==null)
                return string.Format(OutputMessages.CaptainNotFound,selectedCaptainName);

            var vessel = this.vessels.FindByName(selectedVesselName);

            if(vessel==null)
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if(vessel.Captain!=null)
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            vessel.Captain = capitan;
            capitan.AddVessel(vessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain,selectedCaptainName, selectedVesselName);
        }
        public string CaptainReport(string captainFullName)
        {
            var capitan = this.capitans.FirstOrDefault(n => n.FullName == captainFullName);

            return capitan.Report();
        }
        public string VesselReport(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();
        }
        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound,vesselName);

            if (vessel.GetType().Name == nameof(Battleship))
            {
              (vessel as Battleship).ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                (vessel as Submarine).ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }
        public string ServiceVessel(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = this.vessels.FindByName(attackingVesselName);

            if (attackingVessel == null)
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            var defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (defendingVesselName == null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if(attackingVessel.ArmorThickness==0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (defendingVessel.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attackingVessel.Attack(defendingVessel);

            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel,defendingVesselName,attackingVesselName,defendingVessel.ArmorThickness);
        }

    }
}
