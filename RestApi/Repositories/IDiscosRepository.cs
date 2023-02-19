using RestApi.Models;

namespace RestApi.Repositories;

public interface IDiscosRepository
{
    ICollection<DiscoModel> GetDiscos();
}