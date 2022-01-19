using System;
using System.Linq;
using System.Threading.Tasks;
using JWTApi.Data;
using JWTApi.Dtos;
using JWTApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTApi.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
         private readonly DataContext _context;
        public InventoryController(DataContext context)
        {
            _context = context;
            
        }
        
        [AllowAnonymous]
        [HttpGet("{inventores}")]
        public async Task<IActionResult> GetInventoriers(int id)
        {
              var inventores = await _context.Invertories.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Invertories").ToListAsync();

            return Ok(inventores);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostInvertory([FromBody]InventoryDto inventory)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var invertories = new Invertory
            {
                Status = inventory.Status,
                Date = inventory.Date
            };
            await _context.Invertories.AddAsync(invertories);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(invertories);
        }

         [AllowAnonymous]
        [HttpGet("{invertory}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Invertories.FirstOrDefault(x => x.InventoryId == Id);
            _context.Invertories.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }
    }
}