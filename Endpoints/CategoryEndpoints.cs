
using furniro_server.Data;

namespace furniro_server.Endpoints
{
    public static class CategoryEndpoints
    {
        // private readonly ApplicationDbContext _dbContext;

        // public CategoryEndpoints(ApplicationDbContext dbContext)
        // {
        //     _dbContext = dbContext;
        // }
        public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app) 
        {
            

            app.MapGet("/", GetAllCategories);
        }

        private static async Task GetAllCategories(HttpContext context)
        {
            
        }
    }
}