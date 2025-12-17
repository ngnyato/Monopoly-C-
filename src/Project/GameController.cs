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
        public Player CurrentPlayer => playersInGame[turnIndex];
    
        

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
                playersInGame.Clear();
                turnIndex = 0;
                for (int i = 0; i < playersGameList.Length; i++)
                {
                    this.playersInGame.Add(players[playersGameList[i]]);
                }
           
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
        p.hasRolledDices = true;
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
        
        if ( landedHouse.houseType == "Property" || landedHouse.houseType == "Train" )
        {

            if (landedHouse.houseOwner == null)
            {
                Console.WriteLine($"Saiu {moveX}/{moveY} – espaço {landedHouse.houseName}. Espaço sem dono.");
            }
            else if (landedHouse.houseOwner == p)
            {
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse}. Espaço já comprado.");
            }
            else
            {
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse}. Espaço já comprado por outro jogador. Necessário pagar renda.");
                p.hasDemandingAction = true;
                p.hasToPayRent = true;
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
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço Police. Jogador preso.");// TODO : Missing Implementation
                    break;  

                case "Prison":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço Prison. Jogador só de passagem."); 
                    break;

                case "BackToStart":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço BackToStart. Peça colocada no espaço Start."); // TODO missing implementation 
                    break;

                case "Chance":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço especial. Tirar carta.");  
                p.hasDemandingAction = true;
                    break;

                case "Community":
                Console.WriteLine($"Saiu {moveX}/{moveY} - espaço {landedHouse.houseName}. Espaço especial. Tirar carta.");
                p.hasDemandingAction = true;
                    break;


                default:
                    break;
            }
       
        }

        
        
        Console.WriteLine($"DEBUG Saiu x {posX} y {posY} caiu na {landedHouse.houseName}");
         Console.WriteLine($"DEBUG Moveu x {moveX} y {moveY} caiu na {landedHouse.houseName}");
    }

    public void BuySpace ()
    {
        Player p = CurrentPlayer;
        House h = p.CurrentHouse;




        if (h.houseType != "Property" && h.houseType != "Train")
        {
            Console.WriteLine("Este espaço não está para venda.");
            return;
        }

        if (h.houseOwner != null)
         { 
        Console.WriteLine("O espaço já se encontra comprado.");
        return;
         }

         if (p.money < h.housePrice)
         {
        Console.WriteLine("O jogador não tem dinheiro suficiente para adquirir o espaço.");
        return;
            }
    
           p.money = p.money - h.housePrice;
           h.houseOwner = p;
           p.OwnedHouses.Add(h);
    }
    
    public void FinishTurn(string pName)
    {
        Player p = CurrentPlayer;


        if (gameInProgress == false)
        {
            Console.WriteLine("Não existe jogo em curso.");
        }

         if (pName != p.Name)
        {
            Console.WriteLine("Não é o turno do jogador indicado.");
        }

        if (p.hasDemandingAction == true)
        {
            Console.WriteLine("O jogador ainda tem ações a fazer.");
        }

        if (p.hasDemandingAction == false)
        {
            turnIndex++;
            if (turnIndex >= playersInGame.Count) turnIndex = 0;
            Console.WriteLine($"Turno terminado. Novo turno do jogador {playersInGame[turnIndex].Name}.");
        }
    }



    public void PayDueRent()
    {
        Player p = CurrentPlayer;
        House h = p.CurrentHouse;

        double antes = h.housePrice * 0.25 + h.housePrice * 0.75 * h.houseNumber;
        int renda = (int)Math.Round(antes,2);
       


        if (CurrentPlayer.hasToPayRent == false && CurrentPlayer.hasDemandingAction == false)
        {
            Console.WriteLine("Não é necessário pagar aluguel.");
            return;
        }
        if (renda > p.money)
        {
            Console.WriteLine("O jogador não tem dinheiro suficiente.");
            // TODO : implementar falencia
            return; 
        }
        if (gameInProgress == false)
        {
            Console.WriteLine("Não existe um jogo em curso.");
            return;
        }
        bool isInGame = playersInGame.Any(p => p.Name == CurrentPlayer.Name); // verifica se o jogador faz parte do jogo em curso
        if (!isInGame)
        {
            Console.WriteLine("Jogador não participa no jogo em curso.");
            return;
        }
        if (p.Name != playersInGame[turnIndex].Name)
        {
            Console.WriteLine("Não é a vez do jogador.");
            return;
        }
        else 
        {
            p.money = p.money - renda;
            h.houseOwner.money = h.houseOwner.money + renda;
            p.hasToPayRent = false;
            p.hasDemandingAction = false;
        }



        
    }




    
}