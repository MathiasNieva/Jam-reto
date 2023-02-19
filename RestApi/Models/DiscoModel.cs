using System.ComponentModel.DataAnnotations;

namespace RestApi.Models;

public class DiscoModel
{
    [Key]
    public Guid DiscoId { get; set; }
    public string? Nombre { get; set; }
    public int Año { get; set; }
    public ICollection<ArtistaDiscoModel>? ArtistaDiscoModel { get; set; }
}