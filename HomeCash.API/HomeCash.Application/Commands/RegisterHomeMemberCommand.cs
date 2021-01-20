using HomeCash.Application.DTOs;
using MediatR;

namespace HomeCash.Application.Commands
{
    public sealed class RegisterHomeMemberCommand : IRequest<UserDTO>
    {
        public RegisterHomeMemberDTO RegisterHomeMemberDTO { get; }

        public RegisterHomeMemberCommand(RegisterHomeMemberDTO registerHomeMemberDTO)
        {
            RegisterHomeMemberDTO = registerHomeMemberDTO;
        }
    }
}