using HomeCash.Application.DTOs;
using System.Threading.Tasks;

namespace HomeCash.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUserAsync(RegisterDTO registerDTO);
        Task<UserDTO> LoginUserAsync(LoginDTO loginDTO);
        Task<UserDTO> RegisterHomeMemberAsync(RegisterHomeMemberDTO registerHomeMemberDTO);
    }
}