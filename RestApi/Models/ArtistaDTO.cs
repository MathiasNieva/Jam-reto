namespace RestApi.Models;

public class ArtistaDTO
{
    public Guid ArtistaId { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public int Telefono { get; set; }

    public static ArtistaDTO ArtistaToDTO(ArtistModel artista) =>
       new ArtistaDTO
       {
           ArtistaId = artista.ArtistaId,
           Nombre = artista.Nombre,
           Direccion = artista.Direccion,
           Telefono = artista.Telefono
       };

    public static ArtistModel DTOToArtista(ArtistaDTO artista)
    {
        return new ArtistModel
        {
            ArtistaId = artista.ArtistaId,
            Nombre = artista.Nombre,
            Direccion = artista.Direccion,
            Telefono = artista.Telefono
        };
        
    }
}