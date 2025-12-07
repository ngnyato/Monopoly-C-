using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Serialization.Formatters;

public class GameController
    {
        private Dictionary<string, Player> players = new Dictionary<string, Player>();
        bool gameInProgress = false;
        private List<Player> playersInGame = new List<Player>();

        public bool DoPlayerExists(string playerName)
        {
            return players.Keys.Contains(playerName);
        }

        public void RegisterPlayer(string playerName)
        {
            players.Add(playerName, new Player(playerName));
        }

        public bool HasPlayers()
        {
            return players.Count > 0; // return true se a condiçao implicita for verdadeira !!
        }

        public void ListPlayers()
        {
                
                    foreach (var player in players.Values)
                    {
                       Console.WriteLine("{0} {1} {2} {3} {4}",    // Aprender melhor sobre formatação de strings
                       player.Name, player.gamesPlayed, player.wins, player.ties, player.losses); // é um place older para nao usar name + " " + gamesPlayed + " " + wins + " " + ties + " " + losses

                    }
                
        }

            public void StartGame(string[] playersGameList)
            {
                for (int i = 0; i < playersGameList.Length; i++)
                {
                    this.playersInGame.Add(players[playersGameList[i]]);
                }
           
            // implemetar add dinheiro etc etc
                gameInProgress = true;
            }
        
        public bool IsGameInProgress()
        {
            return gameInProgress;
        }
    }