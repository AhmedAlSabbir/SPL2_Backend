using System;
using System.Linq;
using System.Threading.Tasks;
using JWTApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTApi.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class StuffUserController : ControllerBase
    {
        
        private readonly DataContext _context;
        public StuffUserController(DataContext context)
        {
            _context = context;
            

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentes(int id)
        {
              var student = await _context.Students.
             FromSqlRaw("SELECT * from Students where Registration={0}",id).ToListAsync();
            //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(student);

        }

        [AllowAnonymous]
        [HttpGet("{user}/{delete}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Staffs.FirstOrDefault(x => x.StaffId == Id);
            _context.Staffs.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }

        [AllowAnonymous]
        [HttpGet("{users}/{id}")]
        public async Task<IActionResult> GetUsersn(int id)
        {
              var user = await _context.User.
            // FromSqlRaw("SELECT * from Users where Registration={0}",id).ToListAsync();
            FromSqlRaw("SELECT Username,Firstname,Lastname,Contrct,Registration from Users where Registration={0}",id).ToListAsync();

            return Ok(user);

        }

        [AllowAnonymous]
        [HttpGet("{new}/{delete}/{n}/{id}")]
        public IActionResult TransAcc(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Transactions.FirstOrDefault(x => x.TransactionId == Id);
            _context.Transactions.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }

    }
}