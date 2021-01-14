using HomeCash.Application.DTOs;
using MediatR;

namespace HomeCash.Application.Commands
{
    public sealed class RegisterUserCommand : IRequest<UserDTO>
    {
        public RegisterDTO RegisterDTO { get; }

        public RegisterUserCommand(RegisterDTO registerDTO)
        {
            RegisterDTO = registerDTO;
        }
    }
}