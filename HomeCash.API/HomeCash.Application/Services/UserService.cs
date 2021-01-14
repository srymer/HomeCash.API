using AutoMapper;
using HomeCash.Application.DTOs;
using HomeCash.Domain.Entities;
using HomeCash.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeCash.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly HomeBaseRepository _homeBaseRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public UserService(UserRepository userRepository, HomeBaseRepository homeBaseRepository, IMapper mapper, TokenService tokenService)
        {
            _userRepository = userRepository;
            _homeBaseRepository = homeBaseRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> RegisterUser(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<User>(registerDTO);
            var homeBase = _mapper.Map<HomeBase>(registerDTO);
            using var hmac = new HMACSHA512();
            user.UserName = registerDTO.UserName;
            user.Role = "admin";
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            user.PasswordSalt = hmac.Key;
            homeBase.HomeName = registerDTO.HomeName;

            await _userRepository.CreateUser(user);
            await _homeBaseRepository.CreateHomeBase(homeBase);

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role
            };

        }
    }
}
