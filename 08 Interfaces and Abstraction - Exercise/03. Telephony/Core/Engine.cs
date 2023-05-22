namespace Telephony.Core
{
    using Interfaces;
    using IO.Interface;
    using Models;
    using Models.Interfaces;
    using Telephony.Exception;

    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;
        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;
        public Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }
        public Engine(IRead read, IWrite write) : this()
        {
            this.read = read;
            this.write = write;
        }
        public void Run()
        {
            string[] phones = read.ReadLine().Split(' ');
            string[] browseres = read.ReadLine().Split(' ');
            foreach (var phone in phones)
            {

                try
                {
                    if (phone.Length == 7)
                    {
                        write.WriteLine(stationaryPhone.Call(phone));
                    }
                    else if (phone.Length == 10)
                    {
                        write.WriteLine(smartphone.Call(phone));
                    }
                }
                catch (InvalidPhoneNumber ipn)
                {
                    write.WriteLine(ipn.Message);
                }
            }
            foreach (var url in browseres)
            {
                try
                {
                    write.WriteLine(smartphone.Browse(url));


                }
                catch (InvalidBrowse ib)
                {
                    write.WriteLine(ib.Message);
                }
            }

        }
    }
}
