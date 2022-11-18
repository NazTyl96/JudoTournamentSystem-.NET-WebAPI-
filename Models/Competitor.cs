using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JTS.Models;

public class Competitor
{
    [Key]
    public int Id {get; set;}

    [Required]
    [MaxLength(50)]
    public string? FirstName {get; set;}

    [Required]
    [MaxLength(50)]
    public string? LastName {get; set;}

    [Required]
    public char Sex {get; set;}

    [Required]
    public DateTime DateOfBirth {get; set;}

    [Column(TypeName = "decimal(18, 1)")]
    public decimal? ExactWeight {get; set;}

    [Required]
    public string? Club {get; set;}

    [JsonIgnore]
    public ICollection<Tournament>? Tournaments {get; set;}
} 