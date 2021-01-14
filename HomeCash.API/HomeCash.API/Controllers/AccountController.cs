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

        [HttpPost("register")]
        public async Task<UserDTO> RegisterUser(RegisterDTO registerDTO)
        {
            var command = new RegisterUserCommand(registerDTO);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}