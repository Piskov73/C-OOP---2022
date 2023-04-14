namespace _02._Animals
{
    public class Animal
    {

        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name=name;
            FavouriteFood=favouriteFood;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string FavouriteFood
        {
            get { return favouriteFood; }
            private set { favouriteFood = value; }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }

    }
}
