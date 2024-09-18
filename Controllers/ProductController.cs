namespace furniro_server.Controllers
{
    using AutoMapper;
    using furniro_server.Data;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.DTOs.ProductDtos;
    using furniro_server.Models.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ProductController : BaseApiController
    {
        private readonly FurniroContext _context;
        private readonly IMapper _mapper;  

        public ProductController(FurniroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetProducts() {

            var products = await _context.Products.ToListAsync();
            
            if (products == null)
                return NotFound();
            else
                return Ok(_mapper.Map<GetProductDto>(products));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetProductDto>> GetProductById(int id) {

            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<GetProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<GetProductDto>> CreateProduct(AddProductDto addProductDto) {

            var product = _mapper.Map<Product>(addProductDto);

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();


            return Ok(_mapper.Map<GetProductDto>(product));
        }


    }
}