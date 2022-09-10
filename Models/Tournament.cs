using System.ComponentModel.DataAnnotations;
using JTS.Interfaces;

namespace JTS.Models;

public class Tournament
{
    [Key]
    public int Id {get; set;}

    [MaxLength(100)]
    public string? Name {get; set;}

    [Required]
    public DateTime Date {get; set;}
}