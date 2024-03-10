namespace Models;

public class Proizvod 
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public string Naziv { get; set; }

    [MaxLength(50)]
    public string Lokacija { get; set; }    

    public Zalihe ZaliheProizvoda { get; set; }

    public List<Sastojak> ListaSastojaka { get; set; }

    
}