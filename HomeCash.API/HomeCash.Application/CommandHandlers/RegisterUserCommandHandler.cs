using HomeCash.Application.Commands;
using HomeCash.Application.DTOs;
using HomeCash.Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HomeCash.Application.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDTO>
    {
        private readonly UserService _userService;

        public RegisterUserCommandHandler(UserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterUser(request.RegisterDTO);
        }
    }
}