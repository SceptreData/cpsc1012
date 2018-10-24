using System;

namespace DeckOfCards
{
    /*
     * this program displays the card name of a deck for a given card number
     * between 1 and 52.
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and create a new array of int
            int[] deck = new int[52];
            // Declare and initialize a string array.
            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            // Declare another array named Ranks
            string[] ranks = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                              "Jack", "Queen", "King"};

            for (int i = 0; i < deck.Length; i++)
                deck[i] = i;

            // Shuffle the Cards
            Random keygen = new Random();
            for (int i = 0; i < deck.Length; i++)
            {
                int rndIdx = keygen.Next(deck.Length);

                int tmp = deck[i];
                deck[i] = deck[rndIdx];
                deck[rndIdx] = tmp;

            }
            for (int i = 0; i < 5; i++)
            {
                int card = deck[i];
                string suit = suits[card / 13];
                string rank = ranks[card % 13];

                Console.WriteLine($"Card {i+1}: {rank} of {suit}");
            }


        }
    }
}
