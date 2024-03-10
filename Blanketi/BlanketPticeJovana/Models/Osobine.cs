using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models;
public class Osobine
{
    [Key]
    public int ID { get; set; }
    public required string Naziv { get; set; }
    public required string Vrednost { get; set; }
    public required bool ViseVrednosti { get; set; }

    [JsonIgnore]
    public virtual Ptica Ptica { get; set; }

    public List<NepoznataPtica> Nepoznata { get; set; }

}