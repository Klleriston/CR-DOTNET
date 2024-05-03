namespace src;

public class Ticket
{
    public int Id { get; set; }
    public virtual User User { get; set; }
    public string Title { get; set; }
    public bool Open { get; set; }
    public string Description { get; set; }
    public DateTime created { get; set; }
}
