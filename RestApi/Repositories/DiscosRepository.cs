using RestApi.Models;

namespace RestApi.Repositories;

public class DiscosRepository : IDiscosRepository
{
    private readonly ArtistContext _context;

    public DiscosRepository(ArtistContext context)
    {
        _context = context;
    }

    public ICollection<DiscoModel> GetDiscos()
    {
        return _context.Discos.OrderBy(d => d.DiscoId).ToList();
    }
}