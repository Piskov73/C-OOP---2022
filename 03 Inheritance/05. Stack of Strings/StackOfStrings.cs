namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }
        public Stack<string> AddRange(ICollection<string> strings)
        {
            foreach (var str in strings)
            {
                this.Push(str);
            }
            return this;
        }
    }
}
