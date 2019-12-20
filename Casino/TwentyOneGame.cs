using System;
using System.Collections.Generic;
using System.Linq;
using Casino.Interfaces;

namespace Casino.TwentyOne
{
    public class TwentyOneGame : Game, IWalkAway
    {
        //added 'new' below
        public new TwentyOneDealer Dealer { get; set; }
        public override void Play()
        {
            //initialize dealer
            Dealer = new TwentyOneDealer();
            //reset player state (empty list, yet to stay)
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            //reset dealer, consider constructor
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Dealer.Deck.Shuffle(3);

            //show player balances
            //prompt user to submit bet
            //each player bets, building a dictionary of players and their bets
            foreach (Player player in Players)
            {
                Console.WriteLine("{0} has a balance of: {1}", player.Name, player.Balance);
                Console.WriteLine("Place your bet.");
                bool validAnswer = false;
                int bet = 0;
                while (!validAnswer)
                {
                    validAnswer = int.TryParse(Console.ReadLine(), out bet);
                    if (!validAnswer)
                    {
                        Console.WriteLine("Please enter digits only (no decimals).");
                    }
                }
                if (bet < 0)
                {
                    throw new FraudException("Fraud Detected.  Security has been notified.");
                }
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet)
                {
                    return;
                }
                //dict
                Bets[player] = bet;
            }

            //dealing in two rounds
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...\n\n");
                foreach (Player player in Players)
                {
                    //put their name before their dealt card
                    Console.Write("{0}: ", player.Name);
                    //writeline baked into Deal()
                    Dealer.Deal(player.Hand);
                    //on second round
                    if (i == 1)
                    {
                        //check for blackjack
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand);
                        if (blackJack)
                        {
                            //announce winner, add pot to balance
                            Console.WriteLine("BlackJack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);
                            return;
                        }
                    }
                }
                //dealer self-deals
                Console.Write("Dealer: ");
                //writeline baked into Deal()
                Dealer.Deal(Dealer.Hand);
                //on dealers second card
                if (i == 1)
                {
                    //check for blackjack
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer had BlackJack! Everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        //dealer collects all players' bets
                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }
                }
            }

            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        //pause
                        Console.WriteLine("{0} ", card.ToString());
                    }
                    Console.WriteLine("\nDealers cards are: ");
                    foreach (Card card in Dealer.Hand)
                    {
                        //pause
                        Console.WriteLine("{0} ", card.ToString());
                    }
                    Console.WriteLine("\n\nHit or Stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer =="hit") 
                    {
                        Dealer.Deal(player.Hand);
                    }
                    bool busted = TwentyOneRules.IsBusted(player.Hand);
                    if (busted)
                    {
                        Dealer.Balance += Bets[player];
                        Console.WriteLine("{0} Busted! " +
                            "You lose your bet of {1}." +
                            "Your balance is now {2}.",
                            player.Name, Bets[player], player.Balance);
                        Console.WriteLine("Would you like to play again?");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "y")
                        {
                            player.isActivelyPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isActivelyPlaying = false;
                            return;
                        }
                    }

                }
            }
            Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("\n\nDealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying.");
            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer Busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                    Dealer.Balance -= entry.Value;
                }
                return;
            }
            //comparing hands (dealer/player)
            foreach (Player player in Players)
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);
                if (playerWon == null)
                {
                    Console.WriteLine("Push! No one wins.");
                    player.Balance += Bets[player];
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];
                }
                //player wants to play again?
                Console.WriteLine("Play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yeah" || answer == "ya" || answer == "y")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
                }
            }

        }


        public override void ListPlayers()
        {
            Console.WriteLine("21 Players:");
            base.ListPlayers();
        }
        public void WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
