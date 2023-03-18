
namespace MilitaryElite.Models
{
    using MilitaryElite.Models.Interfaces;

    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }
        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        //Part Name: Boat Hours Worked: 2
        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
