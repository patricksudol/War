using System;
using System.Collections.Generic;

namespace WarCardGame.models
{
    public class Game
    {
        public Game(bool simulation)
        {
            MatchOver = false;
            CardDeck = new CardDeck();
            DrawPile = new List<Card>();
            Turn = 1;
            Simulation = simulation;
        }

        public List<Card> UserCards { get; set; }
        public List<Card> ComputerCards { get; set; }
        public bool MatchOver { get; set;}
        private CardDeck CardDeck { get; set; }
        private List<Card> DrawPile { get; set; }
        private int Turn { get; set; }
        private bool Simulation { get; set; }
        
        public void Start()
        {
            (UserCards, ComputerCards) = CardDeck.DealCards();
            Console.WriteLine("Hit enter to begin the match.");
            while (!MatchOver)
                Draw();
            Console.WriteLine("\nThe game is over");
            var winner = UserCards.Count > ComputerCards.Count ? "You have" : "The computer has";
            Console.WriteLine($"{winner} won the game");
        }
        private void Draw()
        {
            if (!Simulation)
                Console.Read();
            if (UserCards.Count < 1 || ComputerCards.Count < 1)
            {
                MatchOver = true;
                return;
            }

            Console.WriteLine($"\nTurn: {Turn}");
            Turn++;
            Console.WriteLine($"Your card count: {UserCards.Count}. Computer's card count: {ComputerCards.Count}.");
            
            var userCard = popCards(1, UserCards)[0];
            var computerCard = popCards(1, ComputerCards)[0];
            
            Func<Card, string> cardInfo = (card) => $"{card.Name} of {card.Suit}"; 
            Console.WriteLine($"You have drawn the {cardInfo(userCard)}. The computer has drawn the {cardInfo(computerCard)}.");

            if (userCard.Value > computerCard.Value)
            {
                Console.WriteLine("You have won!");
                awardDrawPile(UserCards);
            }
            else if (computerCard.Value > userCard.Value)
            {
                Console.WriteLine("The computer has won.");
                awardDrawPile(ComputerCards);
            }
            else
            {
                Console.WriteLine("War!");
                if (UserCards.Count < 4 || ComputerCards.Count < 4)
                {
                    MatchOver = true;
                    return;
                }
                popCards(3, UserCards);
                popCards(3, ComputerCards);
            }


            List<Card> popCards(int numberOfCards, List<Card> cardPile)
            {
                var poppedCards = new List<Card>();
                for(var x = 0; x < numberOfCards; x++)
                {
                    DrawPile.Add(cardPile[0]);
                    poppedCards.Add(cardPile[0]);
                    cardPile.RemoveAt(0);
                }
                return poppedCards;
            }

            void awardDrawPile(List<Card> playerCards)
            {
                playerCards.AddRange(DrawPile);
                DrawPile.Clear();
            }
        }
    }
}
