using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings= new RandomList() {"1","2","9","oiu"};   
            for (int i = 0;i <4; i++) 
            {
                Console.WriteLine(strings.RandomString());
            }
           
        }
    }
}
