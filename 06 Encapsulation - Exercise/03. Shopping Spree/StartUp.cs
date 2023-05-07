namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            List<string> inputPersons = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> inputProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            try
            {
                foreach (var item in inputPersons)
                {
                    string[] token = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = token[0];
                    decimal money = decimal.Parse(token[1]);
                    var person = new Person(name, money);
                    persons.Add(person);
                }
                foreach (var item in inputProducts)
                {
                    string[] token = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = token[0];
                    decimal cost = decimal.Parse(token[1]);
                    var product = new Product(name, cost);
                    products.Add(product);
                }
                string comand = Console.ReadLine();
                while (comand!="END")
                {
                    string[] tokens = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string namePerson = tokens[0];
                    string nameProduct= tokens[1];
                    var person=persons.FirstOrDefault(p=>p.Name==namePerson);
                    if (person!=null)
                    {
                        var product=products.FirstOrDefault(p=>p.Name==nameProduct);
                        if (product!=null)
                        {
                            
                            Console.WriteLine(person.BuyProduct(product));
                        }
                        else
                        {
                            throw new InvalidOperationException(MesaggesException.INVALID_PRODUCT);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(MesaggesException.INVALID_PERSON);
                    }
                    comand = Console.ReadLine();
                }

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
                return;
            }
            foreach (var item in persons) 
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
