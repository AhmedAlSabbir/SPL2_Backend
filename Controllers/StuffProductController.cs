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
    public class StuffProductController : ControllerBase
    {
        private readonly DataContext _context;
        public StuffProductController(DataContext context)
        {
            _context = context;
            

        }
//         [AllowAnonymous]
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetInventoris(int id)
//         {
//               var inventory = await _context.Inventory.
//             // FromSqlRaw("SELECT * from Invertories where InventoryId={0}",id).ToListAsync();
//             FromSqlRaw("SELECT Status,Date from Invertories").ToListAsync();

//             return Ok(inventory);

// // where InventoryId={0}",id


//         }

//          [AllowAnonymous]
//         [HttpGet("{product}/{id}")]
//         public async Task<IActionResult> GetProductes(int id)
//         {
//               var product = await _context.Products.
//              FromSqlRaw("SELECT * from Products where ProductId={0}",id).ToListAsync();
//             // FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

//             return Ok(product);

//         }

        
//          [AllowAnonymous]
//         [HttpGet("{Room}/{new}/{id}")]
//         public async Task<IActionResult> GetRoomes(int id)
//         {
//               var room = await _context.Rooms.
//              FromSqlRaw("SELECT * from Rooms where Room_Id={0}",id).ToListAsync();
//             // FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

//             return Ok(room);

//         }

//         [AllowAnonymous]
//         [HttpGet]
//         public async Task<IActionResult> GetStaffs(int id)
//         {
//             var staffs = await _context.Staffs.
//              FromSqlRaw("SELECT * from Staffs").ToListAsync();
//             // FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

//             return Ok(staffs);

//         }

//          [AllowAnonymous]
//         [HttpGet("{usertype}/{dif}/{all}/{id}")]
//         public async Task<IActionResult> GetUsertypies(int id)
//         {
//               var usertype = await _context.Usertypes.
//              FromSqlRaw("SELECT * from Usertypes where UserId={0}",id).ToListAsync();
//             //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();

//             return Ok(usertype);

//         }
        [AllowAnonymous]
        [HttpGet("{products}")]
        public async Task<IActionResult> GetProducts(int id)
        {
              var products = await _context.Products.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Products").ToListAsync();

            return Ok(products);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostProduct([FromBody]ProductDto product)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var products = new Product
            {
                Name = product.Name,
                date = product.date,
                RejectedProduct = product.RejectedProduct,
                PurchaseProduct = product.PurchaseProduct,
                Rate = product.Rate,
                AvailableProduct = product.AvailableProduct
            };
            await _context.Products.AddAsync(products);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(products);
        }

         [AllowAnonymous]
        [HttpGet("{product}/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Products.FirstOrDefault(x => x.ProductId == Id);
            _context.Products.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }
    }
}