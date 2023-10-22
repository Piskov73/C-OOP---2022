
using EDriveRent.IO.Contracts;
using System.IO;

namespace EDriveRent.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter writer = new StreamWriter("../../../text.txt", false))
            {
                writer.Write("");
            }
        }

        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../text.txt",true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../text.txt",true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
