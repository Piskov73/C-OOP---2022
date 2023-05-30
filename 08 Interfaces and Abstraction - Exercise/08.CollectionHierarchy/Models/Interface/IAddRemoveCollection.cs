namespace CollectionHierarchy.Models.Interface
{
using System.Collections.Generic;
    public interface IAddRemoveCollection : IAddCollection
    {
        IReadOnlyCollection<string > RemoveCollection { get; }

        void Remove();
    }
}
