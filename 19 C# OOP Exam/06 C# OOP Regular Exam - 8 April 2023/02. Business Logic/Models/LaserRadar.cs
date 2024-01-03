namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int INTERFASES_STANDARD = 20082;
        private const int BATERY_USAGE = 5000;
        public LaserRadar()
            : base(INTERFASES_STANDARD, BATERY_USAGE)
        {
        }
    }
}
