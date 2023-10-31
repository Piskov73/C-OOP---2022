using System.IO;
using UniversityCompetition.IO.Contracts;

namespace UniversityCompetition.IO
{
    public class FIleWriter : IWriter
    {
        public FIleWriter() 
        {
            using (StreamWriter sw = new StreamWriter("../../../output.txt", false))
            {
                sw.Write("");
            }
        }
        public void Write(string message)
        {
            using(StreamWriter sw=new StreamWriter("../../../output.txt",true))
            {
                sw.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter sw = new StreamWriter("../../../output.txt", true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
