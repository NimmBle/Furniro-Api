namespace furniro_server.Controllers
{
    using furniro_server.Data;
    using furniro_server.Models.DTOs;
    using furniro_server.Models.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class ProductController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly FurniroContext _context;

        public ProductController(ILogger<ProductController> logger, FurniroContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {

            var Products = await _context.Products.ToListAsync();
            
            if (Products == null)
                return NotFound();
            else
                return Ok(Products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetOneProduct(int id) {
            var product = await _context.Products.FindAsync(id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDTO ProductDTO) {

            var Product = new Product {

                Name = ProductDTO.Name,
                CategoryId = ProductDTO.CategoryId,
                ShortDescription = ProductDTO.ShortDescription,
                LongDescription = ProductDTO.LongDescription,
                Price = ProductDTO.Price,
                Discount = ProductDTO.Discount,
                Quantity = ProductDTO.Quantity,
                IsNew = ProductDTO.IsNew,
                CoverPhoto = ProductDTO.CoverPhoto,
                AdditionalPhotos = ProductDTO.AdditionalPhotos,
                Sizes = ProductDTO.Sizes,
                Colors = ProductDTO.Colors
            };

            await _context.AddAsync(Product);
            await _context.SaveChangesAsync();
            return Ok(Product);
        }


    }
}