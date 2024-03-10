namespace Models;

public class Sastojak 
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public string Naziv { get; set; }

    public Zalihe ZaliheSastojka { get; set; }

    
}