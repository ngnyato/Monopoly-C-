using System.Collections;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters;
#nullable disable
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
        
        public void RollDices(int? testMoveX, int? testMoveY)
    {
        if (turnIndex >= playersInGame.Count)
        turnIndex = 0;

        Player p = playersInGame[turnIndex];

        int moveX, moveY;

        if (testMoveX.HasValue && testMoveY.HasValue)
        {
            moveX = testMoveX.Value;
            moveY = testMoveY.Value;
        }
        else
        {
             
         Random rnd = new Random();
        //Console.WriteLine($"#DEBUG Posicao do jogador antes  {p.Name} X={p.posX} Y={p.posY}");
         moveX = rnd.Next(-3,4); // Min incluido e Max Excluido, gera um numero random 
         moveY = rnd.Next(-3,4);   // TODO resolver a situacao de sair o 0
        }

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

       House landedHouse = BoardManager.Houses[posY, posX];
       p.CurrentHouse = landedHouse;
        
        if (landedHouse == null && landedHouse.houseType == "Property")
        {
            Console.WriteLine($"Saiu {moveX}/{moveY} – espaço {landedHouse}. Espaço sem dono.");
        }
       
        if (landedHouse.houseOwner != null && landedHouse.houseType == "Property")
        {
            if (landedHouse.houseOwner == playersInGame[turnIndex])
            {
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse}. Espaço já comprado.");
            }

            if (landedHouse.houseOwner != playersInGame[turnIndex])
            {
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse}. Espaço já comprado por outro jogador. Necessário pagar renda.");
            }
        }

//         Free Park  
//         Police  
//         Prison  
//          bacl to start 
//          Chance  
//         Community 
        if (landedHouse.houseType == "Special")
        {
           switch(landedHouse.houseName)
            {
                case "FreePark":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço FreePark. Jogador recebe (valorNoFreeParjk)."); // TODO missing implementation 
                    break;

                case "Police":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço Police. Jogador preso.");
                    break;

                case "Prison":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço já comprado por outro jogador. Necessário pagar renda.");
                    break;

                case "BackToStart":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço BackToStart. Peça colocada no espaço Start."); // TODO missing implementation 
                    break;

                case "Chance":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço especial. Tirar carta.");
                    break;

                case "Community":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço especial. Tirar carta.");
                    break;


                default:
                    break;
            }
       
        }

        
        turnIndex++;
        Console.WriteLine($"DEBUG Saiu x {posX} y {posY} caiu na {landedHouse.houseName}");
         Console.WriteLine($"DEBUG Moveu x {moveX} y {moveY} caiu na {landedHouse.houseName}");
    }

    public void BuySpace (Player p)
    {
        House h = p.CurrentHouse;



        if (h.houseType == "Property" && h.houseType != "Train")
        {
            // aqui entra se poder comprar a casa
        }

        if (p.CurrentHouse.houseType != "Property")
        {
            Console.WriteLine("Este espaço não está para venda.");
        }




    }
    
        
    
}