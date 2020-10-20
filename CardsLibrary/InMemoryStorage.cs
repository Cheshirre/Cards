using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardsLibrary
{
    public class InMemoryStorage : IStorage
    {
        private static List<Deck> _decks;

        static InMemoryStorage()
        {
            _decks = new List<Deck>();
        }
        public Deck GetDeck(string name)
        {
            return _decks.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public bool SaveDeck(Deck deck)
        {
            bool status = false;

            try
            {
                var target = _decks.FirstOrDefault(x => x.Name.ToLower() == deck.Name.ToLower());
                if (target == null)
                {
                    _decks.Add(deck);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                //to-do: log exception
            }

            return status;
        }

        public bool DeleteDeck(string name)
        {
            bool status = false;

            try
            {
                var target = _decks.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                if (target != null)
                {
                    _decks.Remove(target);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                //to-do: log exception
            }

            return status;
        }

        public IEnumerable<string> GetDeckNames()
        {
            return _decks.Select(x => x.Name);
        }
    }
}
