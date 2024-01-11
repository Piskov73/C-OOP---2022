namespace ChristmasPastryShop
{
    using ChristmasPastryShop.Core;
    using ChristmasPastryShop.Core.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
