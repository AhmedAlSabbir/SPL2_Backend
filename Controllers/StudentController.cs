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
    public class StudentController : ControllerBase
   {
         private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;
            
        }
        
        [AllowAnonymous]
        [HttpGet("{students}")]
        public async Task<IActionResult> GetStudents(int id)
        {
              var students = await _context.Students.
            //  FromSqlRaw("SELECT * from Transactions where TransactionId={0}",id).ToListAsync();
            FromSqlRaw("SELECT * FROM Students").ToListAsync();

            return Ok(students);

        }
         [AllowAnonymous]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostStudent([FromBody]StudentDto student)
        {
            //   var transactions = await _context.Transactions.
            //  FromSqlRaw("insert into transactions where  Debit = {0}, credit = {1}, date = {2}, AccountTitle = {3}",transaction.Debit, transaction.Credit, transaction.Date, transaction.AccountTitle  ).ToListAsync();
            // //FromSqlRaw("SELECT Status,Date from Invertories where InventoryId={0}",id).ToListAsync();
            // _context.SaveChanges();

            // var number = Int16.Parse(room.Number);
            // var capacity = Int16.Parse(room.Capacity);

            var students = new Student
            {
                Firstname = student.FatherName,
                Lastname = student.Lastname,
                FatherName = student.FatherName,
                MotherName = student.MotherName,
                Address = student.Address,
                BloodGroup = student.BloodGroup,
                DateOfBirth = student.DateOfBirth,
                Religion = student.Religion,
                Nationality = student.Nationality,
                Registration = student.Registration,
                Session = student.Session,
                Department = student.Department,
                HallRoll = student.HallRoll,
                StuffName = student.StuffName
            };
            await _context.Students.AddAsync(students);//this doesnt change in our database
            await _context.SaveChangesAsync();

            return Ok(students);
        }

         [AllowAnonymous]
        [HttpGet("{student}/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var Id = Convert.ToInt16(id);
            var user = _context.Students.FirstOrDefault(x => x.Student_Id == Id);
            _context.Students.Remove(user);
            // _context.Staffs.RemoveRange
            //     (_context.Staffs.Where(x => x.StaffId == Id));
            _context.SaveChanges();

            return Ok(user);

        }
    }
}