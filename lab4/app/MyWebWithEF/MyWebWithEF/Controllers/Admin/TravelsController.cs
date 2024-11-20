using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MyWebWithEF.Controllers.Admin.Base
{
    public class TravelsController : AdminApiController
    {
        private readonly TravelService _productService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TravelsController(TravelService productService, ApplicationDbContext context, IMapper mapper)
        {
            _productService = productService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelDto>>> GetProducts()
        {
            var products = await _productService.GetAllTravelsAsync();
            var productDtos = _mapper.Map<List<TravelDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TravelDto>> GetProduct(int id)
        {
            var product = await _productService.GetTravelByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<TravelDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<TravelDto>> CreateProduct(TravelEditDto model)
        {
            var product = await _productService.AddTravel(model);

            await _context.SaveChangesAsync();

            var productDto = _mapper.Map<TravelDto>(product);
            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, TravelEditDto model)
        {
            model.Id = id;

            var product = _productService.UpdateTravel(model);

            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<TravelDto>(product);
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = _productService.DeleteTravel(id);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}