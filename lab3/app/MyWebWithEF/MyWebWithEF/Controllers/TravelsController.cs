using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[Route("api/[controller]")]
[ApiController]
public class TravelsController : ControllerBase
{
    private readonly TravelService _travelService;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TravelsController(TravelService travelService, ApplicationDbContext context, IMapper mapper)
    {
        _travelService = travelService;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TravelDto>>> GetTravels()
    {
        var travels = await _travelService.GetAllTravelsAsync();
        var travelDtos = _mapper.Map<List<TravelDto>>(travels);
        return Ok(travelDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TravelDto>> GetTravel(int id)
    {
        var travel = await _travelService.GetTravelByIdAsync(id);
        if (travel == null)
        {
            return NotFound();
        }

        var travelDto = _mapper.Map<TravelDto>(travel);
        return Ok(travelDto);
    }

    [HttpPost]
    public async Task<ActionResult<TravelDto>> CreateTravel(TravelEditDto model)
    {
        var travel = await _travelService.AddTravel(model);

        await _context.SaveChangesAsync();

        var travelDto = _mapper.Map<TravelDto>(travel);
        return Ok(travelDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTravel(int id, TravelEditDto model)
    {
        model.Id = id;

        var travel = _travelService.UpdateTravel(model);

        await _context.SaveChangesAsync();

        var categoryDto = _mapper.Map<TravelDto>(travel);
        return Ok(categoryDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTravel(int id)
    {
        var deleted = _travelService.DeleteTravel(id);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}