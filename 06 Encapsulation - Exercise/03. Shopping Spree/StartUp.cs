namespace _3ShoppingSpree
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
            try
            {
                List<string> inputPersons = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries ).ToList();
                List<string> inputProducts = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries).ToList();
                AddPerson(inputPersons, persons);
                AddProduct(inputProducts, products);
                string input=Console.ReadLine();
                while (input!="END")
                {
                    string[] token = input.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string namePerson = token[0];
                    string nameProduct = token[1];
                    Person person=persons.FirstOrDefault(p => p.Name == namePerson);
                    Product product = products.FirstOrDefault(p => p.Name==nameProduct);
                    if(product!=null&&person!=null)
                    {
                        Console.WriteLine(person.AddProduct(product));

                    }
                    input = Console.ReadLine();
                }
                foreach (var pers in persons)
                {
                    Console.WriteLine(pers);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        static void AddPerson(List<string> inputPersons, List<Person> persons)
        {
            foreach (var item in inputPersons)
            {
                string[] person = item.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = person[0];
                decimal money = decimal.Parse(person[1]);
                Person newPerson = new Person(name, money);
                persons.Add(newPerson);

            }
        }
        private static void AddProduct(List<string> inputProducts, List<Product> products)
        {
            foreach (var item in inputProducts)
            {
                string[] product = item.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name= product[0];
                decimal cost= decimal.Parse(product[1]);
                Product newProduct= new Product(name, cost);
                products.Add(newProduct);
            }
        }
    }
}
