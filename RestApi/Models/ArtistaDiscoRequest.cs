namespace RestApi.Models;
public class ArtistaDiscoRequest
{
    public DiscoDTO? DiscoDTO { get; set; }
    public List<Guid>? ArtistIds { get; set; }
}