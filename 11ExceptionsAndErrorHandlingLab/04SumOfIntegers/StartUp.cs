namespace SumOfIntegers
{
    using System;
    public class StartUp
    {
        public static class MessagesExceptions
        {
            public const string NUMBER_OUT_OF_RANGE = "The element '{0}' is out of range!";
            public const string INVALID_FORMAT = "The element '{0}' is in wrong format!";
            public const string STATE_AFTER_PROCESSING = "Element '{0}' processed - current sum: {1}";
        }
        public static void Main(string[] args)
        {
            int sum = 0;
            string[] input = Console.ReadLine()
                .Split(' ');
            foreach (var item in input)
            {
                string element = item;
                try
                {
                    int numb = int.Parse(element);
                   
                    sum += numb;
                }
                catch (OverflowException)
                {
                    Console.WriteLine(string.Format(MessagesExceptions.NUMBER_OUT_OF_RANGE, element));
                }
                catch (FormatException)
                {
                    Console.WriteLine(string.Format(MessagesExceptions.INVALID_FORMAT, element));
                }
                finally
                {
                    Console.WriteLine(String.Format(MessagesExceptions.STATE_AFTER_PROCESSING, element, sum));
                }

            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
