namespace Models;

[Table("Student")]
public class Student
{
    [Key]
    public int ID { get; set; }

    [Range(14000, 19000)]
    public required int Index { get; set; }

    [MaxLength(50)]
    public required string Ime { get; set; }

    [MaxLength(50)]
    public required string Prezime { get; set; }

    public List<Spoj> StudentPredmet { get; set; }

}