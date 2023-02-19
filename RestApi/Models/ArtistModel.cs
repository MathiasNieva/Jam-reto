using System.ComponentModel.DataAnnotations;

namespace RestApi.Models;

public class ArtistModel
{
    [Key]
    public Guid ArtistaId { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public int Telefono { get; set; }
    public ICollection<ArtistaDiscoModel>? ArtistaDiscoModel { get; set; }
}