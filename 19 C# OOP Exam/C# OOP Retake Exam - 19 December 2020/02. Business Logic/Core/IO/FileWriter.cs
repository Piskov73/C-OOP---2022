using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter sr = new StreamWriter("../../../output", false))
            {
                sr.Write("");
            }
        }
        public void WriteLine(string message)
        {
            using (StreamWriter sr=new StreamWriter("../../../output",true))
            {
                sr.WriteLine(message);
            }
        }
    }
}
