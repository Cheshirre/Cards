using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace CardsLibrary
{
    public interface IStorage
    {
        bool SaveDeck(Deck pack);
        Deck GetDeck(string name);
        bool DeleteDeck(string name);
        IEnumerable<string> GetDeckNames();
    }
}