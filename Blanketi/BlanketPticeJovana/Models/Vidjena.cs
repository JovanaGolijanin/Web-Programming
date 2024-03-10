using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models;

public class Vidjena
{
    [Key]
    public int ID { get; set; }
    [Range(0,int.MaxValue)]
    public int BrojVidjenja { get; set; }
    public DateTime Vreme { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [JsonIgnore]
    public Ptica Ptica { get; set; }
    public Podrucje Podrucje { get; set; }

}