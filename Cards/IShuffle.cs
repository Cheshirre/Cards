using CardsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards
{
    public interface IShuffle
    {
        Deck Start(Deck source);
    }
}
