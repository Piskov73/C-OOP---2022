

using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
		
		private string name;
		private int age;
		private string gender;
		public Animal (string name, int age, string gender)
		{
			Name = name;
			Age = age;
			Gender = gender;
		}
		public string Gender
        {
			get { return gender; }
			set
			{
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Invalid input!");
                gender = value; 
			}
		}


		public int  Age
		{
			get { return age; }
		private	set
			{
				if (value <= 0)
                {
                    
                        throw new ArithmeticException("Invalid input!");
                    
                }

                age = value;
			}
		}


		public string Name
		{
			get { return name; }
			set
			{
				if(string.IsNullOrWhiteSpace(value))  throw new ArgumentException("Invalid input!");
				name = value; 
			}
		}

		public virtual string ProduceSound() => "Nothing";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{GetType().Name.ToString()}")
				.AppendLine($"{Name} {Age} {Gender}")
				.AppendLine(ProduceSound());
			return sb.ToString().Trim();
        }

    }
}
