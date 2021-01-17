using HomeCash.Domain.Entities;

namespace HomeCash.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}