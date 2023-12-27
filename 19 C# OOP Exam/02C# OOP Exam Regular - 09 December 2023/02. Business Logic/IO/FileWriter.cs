using NauticalCatchChallenge.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter sr = new StreamWriter("../../../output.txt", false))
            {
                sr.Write("");
            }
        }
        public void Write(string message)
        {
            using (StreamWriter sr = new StreamWriter("../../../output.txt", true))
            {
                sr.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter sr = new StreamWriter("../../../output.txt", true))
            {
                sr.WriteLine(message);
            }
        }
    }
}
