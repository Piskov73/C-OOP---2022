using System;
using System.Text;
using System.Threading.Channels;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string[] comang = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = string.Empty;
                int age = 0;
                string gender = string.Empty;
                if (comang.Length == 3)
                {
                    name = comang[0];
                    age = int.Parse(comang[1]);
                    gender = comang[2];
                }
             
                if (input == "Dog")
                {
                    Dog dog=new Dog(name,age,gender);
                    output.AppendLine(dog.ToString());  
                }
                else if (input == "Frog")
                {
                    var frog=new Frog(name,age,gender);
                    output.AppendLine(frog.ToString());
                }
                else if (input == "Cat")
                {
                    var cat=new Cat(name,age,gender);
                    output.AppendLine(cat.ToString());
                }
              
                else if (input== "Kitten")
                {
                    var kitten =new Kitten(name,age);
                    output.AppendLine(kitten.ToString());

                }
                else if(input == "Tomcat")
                {
                    var tomcat = new Tomcat(name, age);
                    output.AppendLine(tomcat.ToString());
                }
                else
                {
                    output.AppendLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(output.ToString().Trim());
        }
    }
}
