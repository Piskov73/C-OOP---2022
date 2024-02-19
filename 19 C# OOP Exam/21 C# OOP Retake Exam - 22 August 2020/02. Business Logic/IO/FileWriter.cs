using EasterRaces.IO.Contracts;
using System.IO;

namespace EasterRaces.IO
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
