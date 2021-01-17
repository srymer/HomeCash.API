using AutoMapper;
using HomeCash.Application.DTOs;
using HomeCash.Application.Services.Interfaces;
using HomeCash.Domain.Entities;
using HomeCash.Domain.Enums;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeCash.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHomeBaseRepository _homeBaseRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IHomeBaseRepository homeBaseRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _homeBaseRepository = homeBaseRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> RegisterUser(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<RegisterDTO, User>(registerDTO);
            var homeBase = _mapper.Map<RegisterDTO, HomeBase>(registerDTO);
            homeBase.HomeBaseId = Guid.NewGuid();
            using var hmac = new HMACSHA512();
            user.UserName = registerDTO.UserName;
            user.Role = RoleTypeEnum.Admin.ToString();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            user.PasswordSalt = hmac.Key;
            user.HomeBaseId = homeBase.HomeBaseId;
            user.Id = Guid.NewGuid();
            homeBase.HomeName = registerDTO.HomeName;

            await _homeBaseRepository.CreateHomeBase(homeBase);
            await _userRepository.CreateUser(user);
            

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role
            };

        }
    }
}
