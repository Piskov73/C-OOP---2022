using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {
            
        }
        public void PrintMethodsByAuthor()
        {
            Type typeClass = typeof(StartUp);
            MethodInfo[] methods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute att in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {att.Name}");
                    }
                }
            }

        }
    }
}
