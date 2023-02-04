using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    internal class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count== 0;
        }

        public StackOfStrings AddRange(IEnumerable<string> strings)
        {
            foreach (string s in strings)
            { 

                this.Push(s);

            }
            return this;
        }
    }
}
