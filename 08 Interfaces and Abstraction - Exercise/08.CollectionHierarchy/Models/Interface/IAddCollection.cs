namespace CollectionHierarchy.Models.Interface
{
    using System.Collections.Generic;
    public interface IAddCollection
    {
        IReadOnlyCollection<string> AddCollections { get; }
        int Numb { get; }
        void Add(string tex);
    }
}
