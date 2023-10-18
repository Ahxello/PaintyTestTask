using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repository;
        public UsersController(IRepository<User> repository) => _repository = repository;

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetItemsCount() => Ok(await _repository.GetCount());

        [HttpGet("exist/id/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> ExistId(Guid id) => await _repository.ExistId(id) ? Ok(true) : NotFound(false);

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll(Guid id) => Ok(await _repository.GetAll());

        [HttpGet("items[[{Skip:int}:{Count:int}]]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> Get(int Skip, int Count) => Ok(await _repository.Get(Skip, Count));

        [HttpGet("page/{PageIndex:int}/{PageSize:int}")]
        [HttpGet("page[[{PageIndex:int}/{PageSize:int}]]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IPage<User>>> GetPage(int PageIndex, int PageSize)
        {
            var result = await _repository.GetPage(PageIndex, PageSize);
            return result.Items.Any()
                ? Ok(result) : NotFound(result);
        }

        [HttpGet("exist")]
        [HttpPost("exist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> Exist(User user) => await _repository.Exist(user) ? Ok(true) : NotFound(false);

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetById(id);
            if (item is not null)
                return Ok(item);
            return NotFound();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(User user)
        {
            var result = await _repository.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(User item)
        {
            if (await _repository.Update(item) is not { } result) return NotFound();
            return AcceptedAtAction(nameof(GetById), new { id = result.Id }, result);
        } 
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(User user)
        {
            if (await _repository.Delete(user) is not { } result) return NotFound(user);
            return Ok(result);
        }
        
        [HttpDelete("delete/id/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            if (await _repository.DeleteById(id) is not { } result) return NotFound(id);
            return Ok(result);
        }
        [HttpGet("exist/id/{username:string}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> ExistName(string username) => await _repository.ExistName(username) ? Ok(true) : NotFound(false);

        [HttpDelete("delete/id/{username:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByName(string username)
        {
            if (await _repository.DeleteByName(username) is not { } result) return NotFound(username);
            return Ok(result);
        }
        [HttpGet("{username:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string username)
        {
            var item = await _repository.GetByName(username);
            if (item is not null)
                return Ok(item);
            return NotFound();
        }


    }
}
