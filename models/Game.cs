using System;
using System.Collections.Generic;

namespace WarCardGame.models
{
    public class Game
    {
        public Game()
        {
            MatchOver = false;
            CardDeck = new CardDeck();
            DrawPile = new List<Card>();
            Turn = 1;
        }

        public List<Card> UserCards { get; set; }
        public List<Card> ComputerCards { get; set; }
        public bool MatchOver { get; set;}
        private CardDeck CardDeck { get; set; }
        private List<Card> DrawPile { get; set; }
        private int Turn { get; set; }
        
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
            // Console.Read();
            if (UserCards.Count < 1 || ComputerCards.Count < 1)
            {
                MatchOver = true;
                return;
            }

            Console.WriteLine($"\nTurn: {Turn}");
            Turn++;
            Console.WriteLine($"Your card count: {UserCards.Count}. Computer's card count: {ComputerCards.Count}.");
            
            var userCard = UserCards[0];
            UserCards.RemoveAt(0);

            var computerCard = ComputerCards[0];
            ComputerCards.RemoveAt(0);
            
            Func<Card, string> cardInfo = (card) => $"{card.Name} of {card.Suit}"; 

            DrawPile.AddRange(new List<Card>(){ userCard, computerCard });
            Console.WriteLine($"You have drawn the {cardInfo(userCard)}. The computer has drawn {cardInfo(computerCard)}.");

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
                Console.WriteLine("Draw!");
                if (UserCards.Count < 4 || ComputerCards.Count < 4)
                {
                    MatchOver = true;
                    return;
                }
                popCard(3, UserCards);
                popCard(3, ComputerCards);
            }


            void popCard(int numberOfCards, List<Card> cardPile)
            {
                for(var x = 0; x < numberOfCards; x++)
                {
                    DrawPile.Add(cardPile[0]);
                    cardPile.RemoveAt(0);
                }
            }

            void awardDrawPile(List<Card> playerCards)
            {
                playerCards.AddRange(DrawPile);
                DrawPile.Clear();
            }
        }
    }
}
