using CardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards
{
    public class BasicShuffle : IShuffle
    {
        public Deck Start(Deck source)
        {
            Random rand = new Random();

            var count = source.Cards.Count;
            var deck = source.Cards.ToArray();

            for (int i = 0; i < count; i++)
            {
                int r = i + (int)(rand.NextDouble() * (count - i));
                Card t = deck[r];
                deck[r] = deck[i];
                deck[i] = t;
            }

            source.Cards = deck.ToList();

            return source;
        }
    }
}
