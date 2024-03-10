namespace Models;

public class Meni 
{
    [Key]
    public int ID { get; set; }

    public List<Proizvod> ListaProizvoda { get; set; }
    
}