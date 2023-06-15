namespace WildFarm.Factory
{
    using Interfaces;
    using Models.Interfaces;
    using Ecxeptions;
    using Models.Foods;

    public class CreateFood : ICreateFood
    {
        public IFood GetFood(string type, int quantity)
        {
            IFood food;
            //	Vegetable
            if(type== "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            //	Fruit
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            //	Meat
            else if (type == "Meat")
            {
                food=new Meat(quantity);
            }
            //	Seeds
            else if (type == "Seeds")
            {
                food=new Seeds(quantity);
            }
            else
            {
                throw new InvalidTypeFood();
            }
            return food;
        }
    }
}
