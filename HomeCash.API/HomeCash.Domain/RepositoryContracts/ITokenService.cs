using HomeCash.Domain.Entities;

namespace HomeCash.Domain.RepositoryContracts
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}