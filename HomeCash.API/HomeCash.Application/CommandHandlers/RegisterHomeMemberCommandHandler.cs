using HomeCash.Application.Commands;
using HomeCash.Application.DTOs;
using HomeCash.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HomeCash.Application.CommandHandlers
{
    public sealed class RegisterHomeMemberCommandHandler : IRequestHandler<RegisterHomeMemberCommand, UserDTO>
    {
        private readonly IUserService _userService;

        public RegisterHomeMemberCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(RegisterHomeMemberCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterHomeMemberAsync(request.RegisterHomeMemberDTO);
        }
    }
}