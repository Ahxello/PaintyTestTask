﻿using Microsoft.AspNetCore.Http;
using PaintyTestTask.Data;
using PaintyTestTask.Data.Enum;
using PaintyTestTask.Entities;
using PaintyTestTask.Helpers;
using PaintyTestTask.Interfaces;
using PaintyTestTask.Interfaces.Repositories;
using PaintyTestTask.Models;
using System.Security.Claims;

namespace PaintyTestTask.Services
{
    public class AccountService : IAccountService
    {
        private readonly ILogger<AccountService> _logger;
        private readonly IRepository<User> _repository;
        public AccountService(ILogger<AccountService> logger, IRepository<User> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _repository.GetByName(model.Username);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }
                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль"
                    };

                }
                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity> { Data = result, StatusCode = StatusCode.OK, };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                User user = await _repository.GetByName(model.Username);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity> {
                        Description =    "Пользотель с таким логином уже создан",
                    };
                }
                user = new User()
                {
                    Username = model.Username,
                    Name = model.Name,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassword(model.Password)
                };
                await _repository.Add(user);
                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>
                {
                    Data = result,
                    Description = "Пользователь создан",
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
           
        }
    }
}
