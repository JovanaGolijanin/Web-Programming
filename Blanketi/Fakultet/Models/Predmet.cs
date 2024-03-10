using System.Collections.Generic;

namespace Models;

[Table("Predmet")]
public class Predmet
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public required string Naziv { get; set; }

    public List<Spoj> PredmetStudent { get; set; }

}