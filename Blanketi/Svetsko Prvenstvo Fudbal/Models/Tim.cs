namespace Models;

[Table("Tim")]
public class Tim
{
    [Key]
    public int ID { get; set; }

    [MaxLength(50)]
    public required string Naziv { get; set; }
    
    public required string URLSlike { get; set; }
    //[JsonIgnore]
    public List<Utakmica> UtakmicePrvogTima { get; set; }
   // [JsonIgnore]
    public List<Utakmica> UtakmiceDrugogTima { get; set; }
    
}