using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;


        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBunnyName));
                }
                name = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energy = value;
            }
        }



        public ICollection<IDye> Dyes => this.dyes.AsReadOnly();

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public abstract void Work();

    }
}
