using HomeCash.Application.Commands;
using HomeCash.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeCash.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registerMember")]
        public async Task<UserDTO> RegisterHomeMemberAsync(RegisterHomeMemberDTO registerHomeMemberDTO)
        {
            var command = new RegisterHomeMemberCommand(registerHomeMemberDTO);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPost("register")]
        public async Task<UserDTO> RegisterUserAsync(RegisterDTO registerDTO)
        {
          var command = new RegisterUserCommand(registerDTO);
          var result = await _mediator.Send(command);          
          return result;
        }
        
        [HttpPost("login")]
        public async Task<UserDTO> LoginUserAsync(LoginDTO loginDTO)
        {
            var command = new LoginUserCommand(loginDTO);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}