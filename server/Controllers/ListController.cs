using Todo.Models;
using Todo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers{
[Route("api/[controller]")]
[ApiController]
public class ListController : ControllerBase
{
    private readonly ListService _listService;

    public ListController(ListService listService)
    {
        _listService = listService;
    }

    [HttpGet]
    public async Task<IEnumerable<CardList>> GetAllAsync()
    {
        return await _listService.GetAllAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCardList([FromBody] CardList cardList)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _listService.CreateCardList(cardList);
        return Ok(cardList);
    }
}
}