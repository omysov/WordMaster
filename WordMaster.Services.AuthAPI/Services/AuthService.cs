﻿using Microsoft.AspNetCore.Identity;
using WordMaster.Services.AuthAPI.Data;
using WordMaster.Services.AuthAPI.Models;
using WordMaster.Services.AuthAPI.Models.Dto;
using WordMaster.Services.AuthAPI.Services.IServices;

namespace WordMaster.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, IJwtGenerator jwtGenerator)
        {
            _db = db;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            
            if(user==null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            // if user was found, generate JWT 
            var token = _jwtGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                UserName = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.UserName,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if(result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        UserName = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";
        }
    }
}
