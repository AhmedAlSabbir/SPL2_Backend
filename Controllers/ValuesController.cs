using System.Linq;
using System.Threading.Tasks;
using JWTApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
           _context = context;

        }

        //Get api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
                var values = await _context.Values.ToListAsync();

                return Ok(values);
        } 
        //Get api/values/5 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

    }
}