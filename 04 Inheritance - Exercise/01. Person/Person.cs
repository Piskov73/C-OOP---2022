
namespace Person
{
    public class Person
    {
        //(e.g. Name, Age) 
        private  int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public  string Name { get; set; }

        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;

                }
            }
        }
        public  override string ToString()
        {
            return $"Name: {this.Name}, Age: {age}";
        }

    }
}