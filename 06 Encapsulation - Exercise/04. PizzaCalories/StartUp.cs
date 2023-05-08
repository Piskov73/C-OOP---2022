namespace PizzaCalories
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Pizza pizza=null;
            try
            {
                string comand = Console.ReadLine();
                while (comand != "END")
                {
                    string[] ingredientsPizza = comand.Split();
                    if (ingredientsPizza[0] == "Pizza")
                    {
                        string name = ingredientsPizza[1];
                        pizza=new Pizza(name);
                    }
                    else if (ingredientsPizza[0] == "Dough")
                    {
                        string flourType = ingredientsPizza[1];
                        string bakingTechnique = ingredientsPizza[2];
                        double grams = double.Parse(ingredientsPizza[3]);
                        var dough = new Dough(flourType, bakingTechnique, grams);
                        
                        pizza.AddDough(dough);

                    }
                    else if (ingredientsPizza[0] == "Topping")
                    {
                        string name = ingredientsPizza[1];
                        double grams = double.Parse(ingredientsPizza[2]);
                        var toppind = new Topping(name, grams);
                        
                        pizza.AddTopping(toppind);
                    }
                    else
                    {
                        throw new ArgumentException(MessageException.INVALID_INPUT);
                    }

                    comand = Console.ReadLine();
                }
                Console.WriteLine(pizza);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
               
            }


        }
    }
}
