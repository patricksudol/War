using System;
using System.Collections.Generic;
using WarCardGame.helpers;

namespace WarCardGame.models
{
    public class CardDeck
    {
        public CardDeck()
        {
            Cards = new List<Card>();
            FillCardDeck();
        }

        public List<Card> Cards { get; set; }

        public (List<Card>, List<Card>) DealCards()
        {
            var userPile = new List<Card>();
            var computerPile = new List<Card>();
            for (var x = 0; x < Cards.Count; x += 2)
            {
                userPile.Add(Cards[x]);
                computerPile.Add(Cards[x + 1]);
            }
            return (userPile, computerPile);
        }
        
        private void FillCardDeck()
        {
            foreach (var suit in Enum.GetNames(typeof(Suit)))
            {
                foreach (var value in Enum.GetValues(typeof(Value)))
                {
                    var name = Enum.GetName(typeof(Value), value);
                    Cards.Add(new Card() { Name = name,  Suit = suit, Value = (int)value });
                }
            }
            Cards.ShuffleList();
        }
    }
}
