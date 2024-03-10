namespace Models;

[Table("Stadion")]
public class Stadion
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public required string Naziv { get; set; }

    [MaxLength(50)]
    public required string Lokacija { get; set; }

    [Range(0, 500000)]
    public required int Kapacitet { get; set; } 

    public DateTime DatumOtvaranja { get; set; }

    //[JsonIgnore]
    public virtual List<Utakmica> Utakmice { get; set; }


  
}