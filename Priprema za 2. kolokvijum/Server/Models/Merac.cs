using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Merac.Models;

public class Merac
{
    [Key]
    public int ID { get; set; }

    [MaxLength(255)]
    public required string Naziv { get; set; }

    [Range(0, 100)]
    public double Interval { get; set; }

    [MaxLength(30)]
    public required string Boja { get; set; }

    [Range(-10000, 10000)]
    public double GranicaOd { get; set; }

    [Range(-10000, 10000)]
    public double GranicaDo { get; set; }

    [Range(-10000, 10000)]
    public double TrenutnaVrednost { get; set; }

    [Range(-10000, 10000)]
    public double MinimalnaIzmerenaVrednost { get; set; }

    [Range(-10000, 10000)]
    public double MaksimalnaIzmerenaVrednost { get; set; }

    [Range(-10000, 10000)]
    public double ProsecnaIzmerenaVrednost { get; set; }

    [JsonIgnore]
    public int BrojMerenja { get; set; }
}
