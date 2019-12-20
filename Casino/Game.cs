using System;
using System.Collections.Generic;


namespace Casino
{
    public abstract class Game
    {
        //instantiating a private list and dict to prevent getter pointing to null object
        private List<Player> _players = new List<Player>();

        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();

        public List<Player> Players 
        {
            get { return _players; } 
            set { _players = value; } 
        }
        
        public Dictionary<Player, int> Bets 
        {
            get { return _bets; } 
            set { _bets = value; } 
        }

        public string Name { get; set; }
        public string Dealer { get; set; }
        public abstract void Play();
        public virtual void ListPlayers()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }
    }
}
