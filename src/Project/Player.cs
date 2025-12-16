public class Player {
    public string Name;
    public int gamesPlayed;
    public int wins;
    public int losses;
    public int ties;
    public double money = 1200; // TODO: check if this is needed.
    public int posX = 3, posY = 3;
    public House CurrentHouse{get; set;}
    public List<House> OwnedHouses {get; } = new(); // TODO pesquisar o que este comando faz


    


    // FIXME: some fields are missing;

    public Player(string Name) {
        this.Name = Name;
    }
}
    