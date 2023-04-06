namespace ProjetoXadrez.API.Domain;

public class Jogo
{
    public Guid id { get; set; }
    public bool IsFinished { get; set; }
    public bool IsWhiteTurn { get; set; }
    public string[] MoveHistory { get; set; }
    
    public Jogo()
    {
        
    }
}
