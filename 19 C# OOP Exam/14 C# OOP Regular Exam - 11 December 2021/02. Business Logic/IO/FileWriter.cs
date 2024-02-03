using Gym.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gym.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter() 
        {
            using (StreamWriter sr = new StreamWriter("../../../output.text", false))
            {
                sr.Write("");
            }
        }
        public void Write(string message)
        {
            using(StreamWriter sr=new StreamWriter("../../../output.text",true))
            {
                sr.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter sr = new StreamWriter("../../../output.text", true))
            {
                sr.WriteLine(message);
            }
        }
    }
}
