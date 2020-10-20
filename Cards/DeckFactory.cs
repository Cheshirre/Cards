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
                deck.Cards.Add(new Card { Name = $"card {i}", Value = i });
                //to-do: здесь вместо прямого добавления можно было бы использовать какой-нибудь GetNextCard
            }

            deck.Cards.OrderBy(x => x.Value);

            return deck;
        }
    }
}
