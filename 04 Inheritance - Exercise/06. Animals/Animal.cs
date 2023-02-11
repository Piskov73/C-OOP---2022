

using System.Text;

namespace Animals
{
    public class Animal
    {
        //"{Name} {Age} {Gender}"
        public Animal(string name,int age,string gender) 
        {
            Name = name;
            Age = age;
            Gender = gender;
            Sound = "";
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Sound { get; set; }
        public virtual string ProduceSound()
        {
           return Sound;
        }
        public  override  string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetType().Name.ToString());
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
