using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintyTestTask.API.Controllers.Base;
using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.API.Controllers
{
    public class UsersController : EntityController<User>
    {
        public UsersController(IRepository<User> Repository) : base(Repository) { }


    }
}
