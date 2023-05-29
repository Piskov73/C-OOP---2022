namespace MilitaryElite.Models.Interface
{
using System.Collections.Generic;
    public interface ILieutenantGeneral :IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
