﻿namespace Raiding.Models.Interfaces
{
    public interface IBaseHero
    {
        //	BaseHero – string Name, int Power, string CastAbility()
        string Name { get; }
        int Power { get; }
        string CastAbility();
    }
}
