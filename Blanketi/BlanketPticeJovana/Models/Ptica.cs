using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Models;

[Table("Ptica")]
public class Ptica
{
    [Key]
    public int ID { get; set; }
    
    [MaxLength(30)]
    public required string Naziv { get; set; }

    public required string Slika { get; set; }

    public List<Osobine> Osobine { get; set; }

    public List<Vidjena> Vidjena { get; set; }
}