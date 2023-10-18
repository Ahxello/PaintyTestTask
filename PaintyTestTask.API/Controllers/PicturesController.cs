using PaintyTestTask.API.Controllers.Base;
using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.API.Controllers
{
    public class PicturesController : EntityController<Picture>
    {
        public PicturesController(IRepository<Picture> Repository) : base(Repository) { }

    }
}
