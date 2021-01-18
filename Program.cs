using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Hand
    {
        public List<Card> CardsInHand = new List<Card>();

        // public void PlaceInHand(Card cardToPlaceInHand)
        // {
        //     CardsInHand.Add(cardToPlaceInHand);
        // }

        public int TotalValue()
        {
            var grandTotal = 0;

            foreach (var currentCardValue in CardsInHand)
            {

                grandTotal = grandTotal + currentCardValue.Value();
            }

            return grandTotal;

        }


    }

    class Card
    {

        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value()
        {
            switch (Face)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return int.Parse(Face);

                case "10":
                case "Jack":
                case "Queen":
                case "King":
                    return 10;

                case "Ace":
                    return 11;

                default:
                    return 0;


            }
        }

        class Program
        {




            static void Main(string[] args)
            {

                var userChoice = Console.ReadLine().ToUpper().Trim();
                while (userChoice == "YES")
                {
                    var deck = new List<Card>();

                    var suits = new List<string>() { "Club", "Diamond", "Heart", "Spade" };

                    var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "Queen", "King", "Ace" };

                    // var value = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

                    foreach (var currentSuit in suits)
                    {


                        foreach (var currentFace in faces)
                        {
                            var newCard = new Card();

                            newCard.Suit = currentSuit;

                            newCard.Face = currentFace;


                            Console.WriteLine($"The {newCard.Suit} of {newCard.Face} is worth {newCard.Value()}");

                            deck.Add(newCard);



                        }
                    }
                    for (var rightIndex = deck.Count - 1; rightIndex >= 1; rightIndex--)
                    {
                        var randomNumberGenerator = new Random();
                        var leftIndex = randomNumberGenerator.Next(rightIndex);



                        var leftCard = deck[leftIndex];
                        var rightCard = deck[rightIndex];
                        deck[rightIndex] = leftCard;
                        deck[leftIndex] = rightCard;


                    }

                    var playerHand = new Hand();

                    var dealerHand = new Hand();

                    var firstPlayerCard = deck[0];
                    playerHand.CardsInHand.Add(firstPlayerCard);
                    deck.Remove(firstPlayerCard);



                    var secondPlayerCard = deck[0];
                    playerHand.CardsInHand.Add(secondPlayerCard);
                    deck.Remove(secondPlayerCard);



                    var firstDealerCard = deck[0];
                    dealerHand.CardsInHand.Add(firstDealerCard);
                    deck.Remove(firstDealerCard);



                    var secondDealerCard = deck[0];
                    dealerHand.CardsInHand.Add(secondDealerCard);

                    deck.Remove(secondDealerCard);

                    string hitOrStand;


                    do
                    {




                        foreach (var cardInPlayerHand in playerHand.CardsInHand)
                        {
                            Console.WriteLine($"You have the {cardInPlayerHand.Face} of {cardInPlayerHand.Suit}");
                        }


                        var thePlayerTotalValue = playerHand.TotalValue();
                        Console.WriteLine($"Your hand is worth {thePlayerTotalValue}");


                        Console.WriteLine("What do you want? HIT or STAND");
                        hitOrStand = Console.ReadLine();
                        if (hitOrStand == "HIT")
                        {
                            var cardFromSelectingHitOption = deck[0];
                            deck.Remove(cardFromSelectingHitOption);

                            playerHand.CardsInHand.Add(cardFromSelectingHitOption);
                        }
                    } while (hitOrStand == "HIT" && playerHand.TotalValue() < 21);

                    if (playerHand.TotalValue() > 21)
                    {

                        Console.WriteLine($"Your hand is worth {playerHand.TotalValue()}");
                        Console.WriteLine();
                        Console.WriteLine("You have busted");
                    }





                    while (dealerHand.TotalValue() < 17)
                    {
                        var cardDealtToDealer = deck[0];
                        deck.Remove(cardDealtToDealer);
                        dealerHand.CardsInHand.Add(cardDealtToDealer);
                    }

                    Console.WriteLine();
                    foreach (var cardInDealerHand in dealerHand.CardsInHand)
                    {
                        Console.WriteLine($"You have the {cardInDealerHand.Face} of {cardInDealerHand.Suit}");
                    }


                    Console.WriteLine($"THe dealer has {dealerHand.TotalValue()}");

                    if (playerHand.TotalValue() > 21)
                    {
                        Console.WriteLine("DEALER WINS");
                    }

                    else if (dealerHand.TotalValue() > 21)
                    {
                        Console.WriteLine("PLAYER WINS");
                    }
                    else if (dealerHand.TotalValue() >= playerHand.TotalValue())
                    {
                        Console.WriteLine("DEALER WINS");

                    }
                    else
                    {
                        Console.WriteLine("PLAYER WINS");
                    }
                    Console.Write("Would you like to play again? ");
                    userChoice = Console.ReadLine().ToUpper().Trim();
                }

            }








        }

    }

}




