using CardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards
{
    public interface IDeckFactory
    {
        Deck Create(string name, int size);
    }
}
