namespace Cards
{
    using System;
    using System.Collections.Generic;



    public class StartUp
    {
        public class Cards
        {

            private string face;
            private string suit;

            private readonly ICollection<string> cardFaces = new HashSet<string>()
            { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            private readonly ICollection<string> cardSuit = new HashSet<string>()
            { "\u2660", "\u2665", "\u2666", "\u2663" };

            public Cards(string face, string suit)
            {
                this.Fase = face;
                this.Suit = suit;
            }
            public string Fase
            {
                get => face;
                private set
                {
                    if (!cardFaces.Contains(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    face = value;
                }
            }
            public string Suit
            {
                get => suit;
                private set
                {
                    if (!cardSuit.Contains(value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    suit = value;
                }
            }
            public override string ToString()
            {

                return $"[{Fase}{Suit}]";
            }
        }
        static void Main(string[] args)
        {
            List<Cards> cards = new List<Cards>();
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in input)
            {

                try
                {
                    string[] argumentsCards = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string face = argumentsCards[0];
                    string suit = argumentsCards[1];
                    Cards card = CreateCards(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));


        }

        static Cards CreateCards(string face, string suit)
        {
         
            if (suit == "S")
            {
                suit = "\u2660";
            }
            else if (suit == "H")
            {
                suit = "\u2665";
            }
            else if(suit == "D")
            {
                suit = "\u2666";
            }
            else if (suit == "C")
            {
                suit = "\u2663";
            }

            return new Cards(face, suit);
        }
    }
}
