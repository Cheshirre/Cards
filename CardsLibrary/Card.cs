using System;

namespace CardsLibrary
{
    public enum Suit {
        Clubs, //(♣)
        Diamonds, //(♦)
        Hearts, //(♥) 
        Spades //(♠)
    }
    public enum Weight {
       Two,	
       Three,
       Four,
       Five,
       Six,
       Seven,
       Eight,
       Nine,
       Ten,
       Jack,    
       Queen,
       King, 
       Ace
    }

    public class Card
    {
        public Weight Weight { get; set; }
        public Suit Suit { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
