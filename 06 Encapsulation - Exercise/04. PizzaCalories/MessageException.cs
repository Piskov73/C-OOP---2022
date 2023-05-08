

namespace PizzaCalories
{
    public static class MessageException
    {
       
        public const string INVALID_MODIFIERS = "Invalid type of dough.";
        public const string INVALID_GRAMS_RANGE = "Dough weight should be in the range [{0}..{1}].";
        public const string INVALID_TOPPING = "Cannot place {0} on top of your pizza.";
        public const string INVALID_GRAMS_TOPPING = "{0} weight should be in the range [{1}..{2}].";
        public const string INVALID_PIZZA_NAME = "Pizza name should be between {0} and {1} symbols.";
        public const string INVALID_TOPPING_RANGE = "Number of toppings should be in range [0..{0}].";
        public const string INVALID_INPUT = "Invalid input !";

    }
}
