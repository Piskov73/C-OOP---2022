using System;

namespace _04PizzaCalories
{   public class StartUp
    {
        public static void Main(string[] args)
        {
            try
			{
				string comand=Console.ReadLine();
				string[] namePizza=comand.Split(' ');
                Pizza pizza=new Pizza(namePizza[1]);

                comand = Console.ReadLine();

                while (comand!="END")
				{
					string[] tokens = comand.Split(' ');
					switch (tokens[0])
					{
						case "Dough":
							Dough dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
							pizza.AddDough(dough);
							break;
						case "Topping":
							Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
							pizza.AddTopping(topping);
							break;
                    }

					comand=Console.ReadLine();
				}
				Console.WriteLine(pizza);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return;
			}
            

        }
    }
}
