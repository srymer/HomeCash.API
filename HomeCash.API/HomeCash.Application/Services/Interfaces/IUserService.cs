using HomeCash.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCash.Application.Services.Interfaces
{
   public interface IUserService
    {
        Task<UserDTO> RegisterUser(RegisterDTO registerDTO);
    }
}
