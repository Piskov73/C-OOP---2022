namespace CollectionHierarchy.Core
{
    using System;

    using IO.Interface;
    using Interface;
    using Models.Interface;
    using Models;

    public class Engine : IEngine
    {
        private readonly IRead read;
        private readonly IWrite write;
        public Engine(IRead read,IWrite write)
        {
            this.read = read;
            this.write = write;
        }

        public void Run()
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] elements=read.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int numb=int.Parse(read.ReadLine());
            foreach (var text in elements)
            {
                addCollection.Add(text);
                addRemoveCollection.Add(text);
                myList.Add(text);
            }
            for (int i = 0; i < numb; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }
            write.WriteLine(addCollection.ToString());
            write.WriteLine(addRemoveCollection.ToString());
            write.WriteLine(myList.ToString());
            write.WriteLine(string.Join(" ",addRemoveCollection.RemoveCollection));
            write.WriteLine(string.Join(" ", myList.RemoveCollection));

           
        }
    }
}
