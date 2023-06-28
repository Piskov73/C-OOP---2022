namespace StreamProgress.Core
{
    using Interfaces;
    using IO.Interfaces;
    using StreamProgress.Models;
    using StreamProgress.Models.Interfaces;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IFile> collection;
        private Engine()
        {
            this.collection = new HashSet<IFile>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {

            while (true)
            {
                writer.WriteLine("Enter File, Music or End");
                string input = reader.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else if (input == "File")
                {
                    writer.WriteLine("Enter the file name");
                    string name = reader.ReadLine();
                    writer.WriteLine("Enter the file lenght");
                    int lenght = int.Parse(reader.ReadLine());
                    writer.WriteLine("Enter Bytes Sent");
                    int bytesSent = int.Parse(reader.ReadLine());

                    IFile file = new File(name, lenght, bytesSent);
                    collection.Add(file);
                }
                else if (input == "Music")
                {
                    writer.WriteLine("Enter artist");
                    string artist = reader.ReadLine();
                    writer.WriteLine("Enter album");
                    string album = reader.ReadLine();
                    writer.WriteLine("Enter the file lenght");
                    int lenght = int.Parse(reader.ReadLine());
                    writer.WriteLine("Enter Bytes Sent");
                    int bytesSent = int.Parse(reader.ReadLine());
                    IFile music = new Music(artist, album, lenght, bytesSent);
                    collection.Add(music);
                }
            }
            foreach (var item in collection)
            {
                var stream = new StreamProgressInfo(item);
                writer.WriteLine($"{stream.CalculateCurrentPercent()}%");
            }

        }
    }
}
