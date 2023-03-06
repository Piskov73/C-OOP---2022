
using Telephony.Coor.Interface;
using Telephony.Exception;
using Telephony.IO.Interface;
using Telephony.Methods;
using Telephony.Methods.Interface;

namespace Telephony.Coor
{
   
  

    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;

        private readonly ISmartphone smartphone;
        private readonly IStationaryPhone stationaryPhone;

        private Engine()
        {
            this.smartphone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }

        public Engine(IRead rea, IWrite writ) : this() 
        {
            this.read = rea;
            this.write = writ;
          
        }
        public void Run()
        {
            string[] phones = this.read.ReadLain().Split(' ');
            string[] browseres= this.read.ReadLain().Split(' ');
            
                foreach(string phone in phones)
                {
                try
                {
                    if (phone.Length == 10)
                    {
                        write.WriteLine(smartphone.Call(phone));
                    }
                    else if (phone.Length == 7)
                    {
                        write.WriteLine(stationaryPhone.Call(phone));
                    }
                }
                catch (InvalidPhoneNumber exPhon)
                {

                    write.WriteLine(exPhon.Message);
                }
                   
                }
                foreach (var br in browseres)
                {
                try
                {
                    write.WriteLine(smartphone.Browse(br));

                }
                catch (InvalidBrowsingURL url)
                {
                    write.WriteLine(url.Message);
                    
                }
                }
         
        }
    }
}
