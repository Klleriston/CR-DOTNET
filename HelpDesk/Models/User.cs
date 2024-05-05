namespace src;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
