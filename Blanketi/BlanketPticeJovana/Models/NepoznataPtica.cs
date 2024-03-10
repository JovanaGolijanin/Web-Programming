using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Models;

[Table("NepoznataPtica")]
public class NepoznataPtica
{
    [Key]
    public int ID { get; set; }

    public List<Osobine> Osobine { get; set; }
}