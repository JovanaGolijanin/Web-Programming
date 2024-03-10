namespace Models;

[Table("IspitniRok")]
public class IspitniRok
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public required string Naziv { get; set; }

    public List<Spoj> StudentiPredmeti { get; set; }


}