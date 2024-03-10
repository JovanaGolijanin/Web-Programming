namespace Models;

[Table("Utakmica")]
public class Utakmica
{
    [Key]
    public int ID { get; set; }

    [Range(0, 50000)]
    public required int BrojPosetilaca { get; set; }
    public required int PrviRezultat { get; set; }
    public required int DrugiRezultat { get; set; }
    public Tim PrviTim { get; set; }
    public Tim DrugiTim { get; set; }

   [JsonIgnore]
    public virtual Stadion Stadion { get; set; }

}