namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int num =random.Next(0,this.Count);
            string output = this[num];
            this.RemoveAt(num);
            return output;
        }
    }
}
