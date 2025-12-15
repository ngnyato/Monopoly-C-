using System.Collections;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters;

public class GameController
    {
        private Dictionary<string, Player> players = new Dictionary<string, Player>();
        bool gameInProgress = false;
        public string landedHouse = "";
        public int turnIndex = 0;
        public List<Player> playersInGame = new List<Player>();


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

        public void ListPlayers() // TODO : melhorar a apresentaçao daqui para baixo
        {
                
                    foreach (var player in players.Values)
                    {
                       Console.WriteLine($"{player.Name} {player.gamesPlayed} {player.wins} {player.ties} {player.losses}"); // é um place older para nao usar name + " " + gamesPlayed + " " + wins + " " + ties + " " + losses
                    }
                
        }

            public void StartGame(string[] playersGameList)
            {
                for (int i = 0; i < playersGameList.Length; i++)
                {
                    this.playersInGame.Add(players[playersGameList[i]]);
                }
           
            //TODO implemetar add dinheiro etc etc
                gameInProgress = true;

            }
        
        public bool IsGameInProgress()
        {
            return gameInProgress;
        }
        
        public void RollDices()
    {
        if (turnIndex >= playersInGame.Count)
        {
            turnIndex = 0;
        }
        Player p = playersInGame[turnIndex];
        Random x = new Random();
        Random y = new Random();
        //Console.WriteLine($"#DEBUG Posicao do jogador antes  {p.Name} X={p.posX} Y={p.posY}");
        int moveX = x.Next(-3,4); // Min incluido e Max Excluido, gera um numero random 
        int moveY = y.Next(-3,4); 

        int posX = p.posX + moveX;
        int posY = p.posY + moveY;

         int width  = BoardManager.Houses.GetLength(1); // linhas X e 
         int height = BoardManager.Houses.GetLength(0); // colunas Y

         if (posX < 0)
           posX += width;
         else if (posX >= width)
           posX -= width;
                                             // TODO : documentar isto  
        if (posY < 0)
           posY += height;
         else if (posY >= height)
           posY -= height;
         
        playersInGame[turnIndex].posX = posX;
        playersInGame[turnIndex].posY = posY;   

        landedHouse = BoardManager.Houses[posY, posX].houseName;
        Console.WriteLine($" Debug o player {p.Name} saiu x {posX} e y {posY}, caiu na {landedHouse}");

        switch (landedHouse)
        {
            case "Start":
                p.money += 200;
                Console.WriteLine($"{p.Name} recebeu 200 por passar na Start. Saldo atual: {p.money}");
                break;
            case "LuxTax":
                p.money -= 100;
                Console.WriteLine($"{p.Name} pagou 100 de LuxTax. Saldo atual: {p.money}");
                break;
            case "IncomeTax":
                p.money -= 200;
                Console.WriteLine($"{p.Name} pagou 200 de IncomeTax. Saldo atual: {p.money}");
                break;
            // Adicione mais casos conforme necessário
            default:
                // Nenhum evento especial
                break;
        }



        
        
       
       
       
       
       
       
       
        turnIndex++;
    }
    }