using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace MyWebWithEF.Controllers.User.Base
{
    public class TravelsController : UserApiController
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
    }
}
