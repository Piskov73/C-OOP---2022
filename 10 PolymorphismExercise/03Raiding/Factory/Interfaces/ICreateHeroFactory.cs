using Raiding.Models.Interfaces;

namespace Raiding.Factory.Interfaces
{
    public interface ICreateHeroFactory
    {
        IBaseHero CreateHeroFactory(string name,string type);
    }
}
