﻿namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMissions> Missions { get; }
    }
}
