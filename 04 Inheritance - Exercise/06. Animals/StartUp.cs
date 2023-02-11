using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string[] infoAnimal = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (infoAnimal.Length < 3)
                {
                    sb.AppendLine("Invalid input!");
                }
                else
                {
                    //(string name,int age,string gender) 
                    string name = infoAnimal[0];
                    int age = int.Parse(infoAnimal[1]);
                    string gwnder = infoAnimal[2];
                    if (age <= 0)
                    {
                        sb.AppendLine("Invalid input!");
                    }
                    else
                    {
                        // Dog
                        if(input== "Dog")
                        {
                            var dog=new Dog(name,age,gwnder);
                            sb.Append(dog);
                        }
                        // Cat: 
                        else if(input== "Cat")
                        {
                            var cat=new Cat(name,age,gwnder); sb.Append(cat);
                        }
                        // Frog
                        else if  (input== "Frog")
                        {
                            var frog=new Frog(name,age,gwnder);
                            sb.Append(frog);
                        }
                        // Kittens
                        else if(input== "Kittens")
                        {
                            var kittens=new Kittens(name,age,gwnder);

                            sb.Append(kittens);
                        }
                        // Tomcat
                        else if(input == "Tomcat")
                        {
                            var tomcat=new Tomcat(name,age,gwnder);
                            sb.Append(tomcat);
                        }
                        else
                        {
                            sb.AppendLine("Invalid input!");
                        }
                        sb.AppendLine();
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
