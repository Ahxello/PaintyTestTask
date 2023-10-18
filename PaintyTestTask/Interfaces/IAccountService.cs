using PaintyTestTask.Data;
using PaintyTestTask.Entities;
using PaintyTestTask.Models;
using System.Security.Claims;

namespace PaintyTestTask.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
        ClaimsIdentity Authenticate(User user);
    }
}
