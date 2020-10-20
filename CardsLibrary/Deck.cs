using System;
using System.Collections.Generic;
using System.Text;

namespace CardsLibrary
{
    public class Deck
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public int Size { get; set; }
    }
}
