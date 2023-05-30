namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Interface;
    public class AddRemoveCollection : IAddRemoveCollection
    {
        protected readonly List<string> addCollections;
        protected readonly List<string> addRemoveCollections;
        public AddRemoveCollection()
        {
            this.addCollections = new List<string>();
            this.addRemoveCollections = new List<string>();
            this.Numb = 0;
        }

        public IReadOnlyCollection<string> RemoveCollection => (IReadOnlyCollection<string>)this.addRemoveCollections;

        public IReadOnlyCollection<string> AddCollections => (IReadOnlyCollection<string>)this.addCollections;

        public int Numb { get; private set; }

        public void Add(string tex)
        {
           this.addCollections.Add(tex);
            Numb++;
        }

        public void Remove()
        {
            string remuv = this.addCollections[0];
             
            this.addRemoveCollections.Add(remuv);

            this.addCollections.RemoveAt(0);

        }
        public override string ToString()
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < Numb; i++)
            {
                ints.Add(0);
            }
            return string.Join(' ', ints);
        }
    }
}
