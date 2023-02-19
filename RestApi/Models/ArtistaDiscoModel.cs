namespace RestApi.Models;
public class ArtistaDiscoModel
{
    public Guid ArtistaId { get; set; }
    public Guid DiscoId { get; set; }
    public ArtistModel? Artista { get; set; }
    public DiscoModel? Disco { get; set; }
}