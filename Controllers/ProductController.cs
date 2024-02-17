using Microsoft.AspNetCore.Mvc;
using QueryCraft.Interfaces;
using QueryCraft.SampleApp.Data;
using QueryCraft.SampleApp.Models;

namespace QueryCraft.SampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public QueryCraftContext _dbContext;
        private IParser _parser;

        public ProductController(QueryCraftContext dbContext, IParser parser)
        {
            _parser = parser;
            _dbContext = dbContext;
        }

        [HttpPost(Name = "GetProducts")]
        public IActionResult Get(Dictionary<string, object> model)
        {
            try
            {
                var operand = _parser.Parse(model, typeof(Product));
                return Ok(_dbContext.Products.Where(operand.GetPredicate<Product>()));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
