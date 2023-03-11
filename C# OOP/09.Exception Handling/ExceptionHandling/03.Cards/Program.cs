using System;
using System.Collections.Generic;

namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Card> deck = new List<Card>();
            string[] input = Console.ReadLine().Split(", ");
            foreach (var card in input)
            {
                string face = card.Split(' ')[0];
                string suit = card.Split(' ')[1];
                try
                {
                    Card currCard = CreateCard(face, suit);
                    deck.Add(currCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            Console.WriteLine(String.Join(" ",deck));
        }


        public class Card
        {
            private string face;
            private string suit;

            public string Suit
            {
                get { return suit; }
                set { suit = value; }
            }


            public string Face
            {
                get { return face; }
                set { face = value; }
            }

            public Card(string face, string suit)
            {
                this.Face = face;
                this.Suit = suit;
            }

            public override string ToString()
            {
                switch (suit)
                {
                    case "S": return $"[{face}{"\u2660"}]";
                    case "H": return $"[{face}{"\u2665"}]";
                    case "D": return $"[{face}{"\u2666"}]";
                    case "C": return $"[{face}{"\u2663"}]";
                    default:
                        break;
                }
                return "";
            }
        }

        public static Card CreateCard(string face, string suit)
        {
            if (face != "2" && face != "3" && face != "4" && face != "5" && face != "6" && face != "7" && face != "8" && face != "9" && face != "10" && face != "A" && face != "J" && face != "Q" && face != "K")
            {
                throw new ArgumentException("Invalid card!");
            }
            if (suit != "S" && suit != "D" && suit != "C" && suit != "H")
            {
                throw new ArgumentException("Invalid card!");
            }
            return new Card(face, suit);
        }
    }
}
