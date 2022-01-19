using System;
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

    public class StuffTransactionController : ControllerBase
    {
        
        private readonly DataContext _context;
        public StuffTransactionController(DataContext context)
        {
            _context = context;
            

        }

        [AllowAnonymous]
        [HttpGet("{new}/{id}")]
        public async Task<IActionResult> GetTransactionsn(int id)
        {
              var transaction = await _context.Transactions.
             FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

            return Ok(transaction);

        }

         [AllowAnonymous]
        [HttpGet("{staff}/{all}/{div}/{id}")]
        public async Task<IActionResult> GetStaffs(int id)
        {
              var staffs = await _context.Staff.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT Username,Phone from Staffs where StaffId={0}",id).ToListAsync();

            return Ok(staffs);

        }

        [AllowAnonymous]
        [HttpGet("{transactions}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
              var transactions = await _context.Transactions.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Transactions").ToListAsync();

            return Ok(transactions);

        }

        [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostTransactionsn([FromBody]TransactionDto transaction)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var debit = Int16.Parse(transaction.Debit);
            // var credit = Int16.Parse(transaction.Credit);

            var transactions = new Transaction
            {
                Debit = transaction.Debit,
                Credit = transaction.Credit,
                Date = transaction.Date,
                AccountTitle = transaction.AccountTitle,
                Description = transaction.Description,
                StaffName = transaction.StaffName
            };
            await _context.Transactions.AddAsync(transactions);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(transactions);
        }

    }
 
}