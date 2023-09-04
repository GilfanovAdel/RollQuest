namespace Domain.Entities;

public class Room
{
    public Guid Id { get; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public List<Guid> Players { get; set; }
    
    public  string State { get; set; }
    
    public  Guid Master { get; set; }
    
    //public  Setings setings {get;set;}
}