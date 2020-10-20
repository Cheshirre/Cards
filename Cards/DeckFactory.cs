using CardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards
{
    public class DeckFactory : IDeckFactory
    {
        public Deck Create(string name, int size)
        {
            Deck deck = new Deck { 
                Name = name,
                Size = size,
                Cards = new List<Card>()
            };

            for (var i = 0; i < size; i++)
            {
                if (i == 0)
                    deck.Cards.Add(new Card { Name = $"card {i}", Value = i, Suit = Suit.Clubs, Weight = Weight.Two });
                else
                    deck.Cards.Add(GetNextCard(i, $"card {i}", deck.Cards.Last()));
            }

            deck.Cards.OrderBy(x => x.Value);

            return deck;
        }

        private Card GetNextCard(int i, string name, Card lastCard)
        {
            Card card = new Card
            { 
                Name = name, 
                Value = i, 
                Suit = lastCard.Weight != Weight.Ace ? lastCard.Suit : lastCard.Suit++, 
                Weight = lastCard.Weight != Weight.Ace ? lastCard.Weight++ : Weight.Two
            };

            return card;
        }
    }
}
