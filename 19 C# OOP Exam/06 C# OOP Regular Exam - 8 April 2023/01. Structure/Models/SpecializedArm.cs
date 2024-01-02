namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int INTERFASES_STANDARD = 10045;
        private const int BATERY_USAGE = 10000;

        public SpecializedArm()
            : base(INTERFASES_STANDARD, BATERY_USAGE)
        {
        }
    }
}
