using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {

        private VesselRepository vessels;
        private List<ICaptain> captains;


        public Controller()
        { 
            this.vessels = new VesselRepository();
            this.captains= new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
           var captain=this.captains.FirstOrDefault(c=>c.FullName==fullName);
            if (captain != null)
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            captain=new Captain(fullName);
            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var vessel = this.vessels.FindByName(name);

            if(vessel != null)
                return string.Format(OutputMessages.VesselIsAlreadyManufactured,vessel.GetType().Name,name);

            if (vesselType == nameof(Submarine))
            {
                vessel= new Submarine(name,mainWeaponCaliber,speed);
            }
            else if(vesselType==nameof(Battleship))
            {
                vessel=new Battleship(name,mainWeaponCaliber,speed);
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
          var capitan=this.captains.FirstOrDefault(n=>n.FullName==selectedCaptainName);

            if(capitan==null)
                return   string.Format(OutputMessages.CaptainNotFound,selectedCaptainName);

            var vessel=this.vessels.FindByName(selectedVesselName);

            if(vessel==null)
                return string.Format(OutputMessages.VesselNotFound,selectedVesselName);

            if(vessel.Captain!=default)
                return string.Format(OutputMessages.VesselOccupied,selectedVesselName);

            vessel.Captain = capitan;
            capitan.AddVessel(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain,selectedCaptainName,selectedVesselName);

        }


        public string CaptainReport(string captainFullName)
        {
            var capitan = this.captains.FirstOrDefault(n => n.FullName == captainFullName);
            return capitan.Report();
        }

        public string VesselReport(string vesselName)
        {
            var vessel = this.vessels.FindByName(vesselName);
            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
           var vessel=this.vessels.FindByName(vesselName);
            if(vessel == null)
                return string.Format(OutputMessages.VesselNotFound,vesselName);

            if (vessel.GetType().Name == nameof(Battleship))
            {
                (vessel as Battleship).ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode,vesselName);
            }
            (vessel as Submarine).ToggleSubmergeMode();
            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
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
            if(attackingVessel == null)
                return string.Format(OutputMessages.VesselNotFound,attackingVesselName);

            var defendingVessel=this.vessels.FindByName(defendingVesselName);
            if(defendingVessel==null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if(attackingVessel.ArmorThickness==0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if(defendingVessel.ArmorThickness==0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return string.Format(OutputMessages.SuccessfullyAttackVessel,defendingVesselName,attackingVesselName,defendingVessel.ArmorThickness);
        }

    }
}
