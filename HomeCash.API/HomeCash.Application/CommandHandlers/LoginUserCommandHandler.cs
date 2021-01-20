using HomeCash.Application.Commands;
using HomeCash.Application.DTOs;
using HomeCash.Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HomeCash.Application.CommandHandlers
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserDTO>
    {
        private readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.LoginUserAsync(request.LoginDTO);
        }
    }
}