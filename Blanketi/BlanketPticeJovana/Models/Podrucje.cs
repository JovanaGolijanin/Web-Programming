using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Podrucje
{
    [Key]
    public int ID { get; set; }
    
    [MaxLength(30)]
    public required string Naziv { get; set; }

    public List<Vidjena> Vidjenja { get; set; }


}