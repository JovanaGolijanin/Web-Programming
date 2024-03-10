namespace Models;

[Table("Spoj")]
public class Spoj
{
    [Key]
    public int ID { get; set; }

    [Range(6,10)]
    public int Ocena { get; set; }

    [JsonIgnore]
    public virtual Student Studenti { get; set; }

    [JsonIgnore]
    public virtual Predmet Predmeti { get; set; }

    [JsonIgnore]
    public virtual IspitniRok IspitniRokovi { get; set; }
}