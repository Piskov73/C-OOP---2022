namespace Raiding.Factory
{
    using System;

    using Interfaces;
    using Models.Interfaces;
    using MessagesEcxeptions;
    using Models;

    public class CreateHeroFactory : ICreateHeroFactory
    {
        public CreateHeroFactory()
        {

        }
        IBaseHero ICreateHeroFactory.CreateHeroFactory(string name, string type)
        {
            IBaseHero baseHero;

            if (type == "Druid")
            {
                //Druid
                baseHero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                //Paladin
                baseHero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                //Rogue 
                baseHero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                //Warrior 

                baseHero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException(string.Format(Messages.INVALID_HERO));
            }

            return baseHero;
        }
    }
}
