namespace PlayCatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
               .Split().Select(int.Parse).ToArray();
         
            int count = 0;
            while (count<3)
            {
                string[] manipulateArray = Console.ReadLine().Split();
                try
                {
                    string comand = manipulateArray[0];
                    int index = int.Parse(manipulateArray[1]);
                    if (comand == "Replace")
                    {
                      int element = int.Parse(manipulateArray[2]);
                        input[index] = element;
                    }
                    else if(comand == "Print")
                    {
                        int endIndex = int.Parse(manipulateArray[2]);
                        if (index < 0 || endIndex < 0 || index >= input.Length || endIndex >= input.Length)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        Console.WriteLine(string.Join(", ",GetArrey(index,endIndex,input)));
                    }
                    else if (comand == "Show")
                    {
                        Console.WriteLine(input[index]);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch(FormatException )
                {
                    count++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch(IndexOutOfRangeException )
                {
                    count++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (Exception)
                {

                    throw;
                }
               
                
            }
            Console.WriteLine(string.Join(", ",input));

        }
         
        private static int[] GetArrey(int start,int end , int[] input)
        {
            List<int> result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                result.Add(input[i]);
            }

            return result.ToArray();
        }
      
    }
}
