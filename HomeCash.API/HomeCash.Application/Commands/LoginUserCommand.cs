using HomeCash.Application.DTOs;
using MediatR;

namespace HomeCash.Application.Commands
{
    public sealed class LoginUserCommand : IRequest<UserDTO>
    {
        public LoginDTO LoginDTO { get; }

        public LoginUserCommand(LoginDTO loginDTO)
        {
            LoginDTO = loginDTO;
        }
    }
}