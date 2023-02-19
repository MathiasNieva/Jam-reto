namespace RestApi.Models;

public class DiscoDTO
{
    public Guid DiscoId { get; set; }
    public string? Nombre { get; set; }
    public int Año { get; set; }

    public static DiscoDTO DiscoToDTO(DiscoModel disco) =>
       new DiscoDTO
       {
           DiscoId = disco.DiscoId,
           Nombre = disco.Nombre,
           Año = disco.Año
       };

    public static DiscoModel DTOToDisco(DiscoDTO disco)
    {
        return new DiscoModel
        {
            DiscoId = disco.DiscoId,
            Nombre = disco.Nombre,
            Año = disco.Año
        };
        
    }
}