using Todo.Models;
using Todo.ModelsDTO;
using Todo.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace Todo.Controllers{
[Route("api/[controller]s")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly CardService _cardService;

    public CardController(IMapper mapper, CardService cardService)
    {
        _mapper = mapper;
        _cardService = cardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var cards = await _cardService.GetAllAsync();
        return Ok(_mapper.Map<List<CardDTO>>(cards));   
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCardById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var card = await _cardService.GetCardById(id);

        return Ok(_mapper.Map<CardDTO>(card));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCard([FromBody] CardDTO cardDTO)
    {
        var card = _mapper.Map<Card>(cardDTO);
        var createdCard = await _cardService.CreateCard(card);

        var cardResource = _mapper.Map<CardDTO>(createdCard);
        return CreatedAtAction(nameof(GetCardById), new { id = createdCard.Id }, cardResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCard(int id, [FromBody] Card card)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _cardService.UpdateCard(id, card);
        return Ok();
    }

    [HttpPut("move/{id}")]
    public async Task<IActionResult> MoveCard(int id, [FromBody] Card card)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _cardService.MoveCard(id, card);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(int id)
    {
        await _cardService.DeleteCard(id);
        return Ok();
    }
}}
