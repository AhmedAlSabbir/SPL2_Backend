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
    public class RoomController : ControllerBase
    {
         private readonly DataContext _context;
        public RoomController(DataContext context)
        {
            _context = context;
            
        }
        
        [AllowAnonymous]
        [HttpGet("{rooms}")]
        public async Task<IActionResult> GetRooms(int id)
        {
              var rooms = await _context.Rooms.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Rooms").ToListAsync();

            return Ok(rooms);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostRoom([FromBody]RoomDto room)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var rooms = new Room
            {
                RoomNumber = room.RoomNumber,
                Capacity = room.Capacity,
                Building = room.Building,
                StudentPhoneNo = room.StudentPhoneNo,
                AdmitDate = room.AdmitDate,
                LeftDate = room.LeftDate,
                HallFee = room.HallFee,
                FeeYear = room.FeeYear,
                HallRoll = room.HallRoll
            };
            await _context.Rooms.AddAsync(rooms);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(rooms);
        }

         [AllowAnonymous]
        [HttpGet("{room}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Rooms.FirstOrDefault(x => x.Room_Id == Id);
            _context.Rooms.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }
    }
}