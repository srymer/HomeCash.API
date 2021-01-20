using AutoMapper;
using HomeCash.Application.DTOs;
using HomeCash.Application.Services.Interfaces;
using HomeCash.Domain.Entities;
using HomeCash.Domain.Enums;
using HomeCash.Domain.RepositoryContracts;
using HomeCash.Infrastructure.EFCore.DbContexts;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeCash.Application.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IHomeBaseRepository _homeBaseRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService( IUserRepository userRepository, IHomeBaseRepository homeBaseRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _homeBaseRepository = homeBaseRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<UserDTO> LoginUserAsync(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByUserNameAsync(loginDTO.UserName);
            if (user == null) throw new Exception("Niepoprawny login lub hasło");
            var home = await _homeBaseRepository.GetHomeBaseByIdAsync(user.HomeBaseId);
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) throw new Exception("Niepoprawny login lub hasło");
            }
            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role,
                HomeName=home.HomeName,
                HomeBaseId=user.HomeBaseId
            };
        }

        public async Task<UserDTO> RegisterHomeMemberAsync(RegisterHomeMemberDTO registerHomeMemberDTO)
        {
            var user = _mapper.Map<RegisterHomeMemberDTO, User>(registerHomeMemberDTO);
            var homeBase = await _homeBaseRepository.GetHomeBaseByIdAsync(registerHomeMemberDTO.HomeBaseId);
            using var hmac = new HMACSHA512();
            user.UserName = registerHomeMemberDTO.UserName.ToUpper();
            user.Role = registerHomeMemberDTO.Role;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerHomeMemberDTO.Password));
            user.PasswordSalt = hmac.Key;
            user.HomeBaseId = registerHomeMemberDTO.HomeBaseId;
            user.Id = Guid.NewGuid();
            
            await _userRepository.CreateUserAsync(user);

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role,
                HomeName = homeBase.HomeName,
                HomeBaseId=user.HomeBaseId
            };
        }

        public async Task<UserDTO> RegisterUserAsync(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<RegisterDTO, User>(registerDTO);
            var homeBase = _mapper.Map<RegisterDTO, HomeBase>(registerDTO);
            homeBase.HomeBaseId = Guid.NewGuid();
            using var hmac = new HMACSHA512();
            user.UserName = registerDTO.UserName.ToUpper();
            user.Role = RoleTypeEnum.Admin.ToString();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            user.PasswordSalt = hmac.Key;
            user.HomeBaseId = homeBase.HomeBaseId;
            user.Id = Guid.NewGuid();
            homeBase.HomeName = registerDTO.HomeName.ToUpper();

            await _homeBaseRepository.CreateHomeBaseAsync(homeBase);
            await _userRepository.CreateUserAsync(user);

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role,
                HomeName=homeBase.HomeName,
                HomeBaseId=homeBase.HomeBaseId                
            };
        }
    }
}