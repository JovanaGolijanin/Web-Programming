namespace Models;

public class Prodavnica 
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public string Naziv { get; set; }

    [MaxLength(50)]
    public string Lokacija { get; set; }   

    public Meni Menii { get; set; } 

    public Zalihe ZaliheUProdavnici { get; set; }
    
}
