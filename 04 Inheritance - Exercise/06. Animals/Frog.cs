

namespace Animals
{
    public class Frog : Animal
    {
       
        private const string FROG_SOUND = "Ribbit";
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public override string Sound => FROG_SOUND;
        public override string ToString()
        {
            return base.ToString();

        }
    }
}
