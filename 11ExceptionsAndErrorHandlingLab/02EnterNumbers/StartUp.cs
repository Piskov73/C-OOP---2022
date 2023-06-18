namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",ReadNumber()));
        }
       private static List<int> ReadNumber()
        {
            List<int> numbersCollection = new List<int>();
            int count = 1;
            while (numbersCollection.Count < 10)
            {
                try
                {
                    int numb = int.Parse(Console.ReadLine());
                    if (numb <= count || numb >= 100)
                    {
                        throw new ArgumentException($"Your number is not in range {count} - 100!");
                    }
                    count=numb;
                    numbersCollection.Add(numb);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }
            return numbersCollection;
        }
    }
}
