namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Models.Interface;
    using System.Collections.Generic;
    public class AddCollection : IAddCollection
    {
        private readonly ICollection<string> addCollections;
        public AddCollection()
        {
            this.addCollections = new List<string>();
            this.Numb = 0;
        }

        public  IReadOnlyCollection<string> AddCollections => (IReadOnlyCollection<string>)this.addCollections;

        public int Numb { get;protected set; }

        public void Add(string tex)
        {
            addCollections.Add(tex);
            this.Numb++;
        }
        public override string ToString()
        {
            List<int> ints = new List<int>();
            for (int i = 0;i<Numb;i++)
            {
                ints.Add(i);
            }
            return string.Join(' ',ints);
        }
    }
}
