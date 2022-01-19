using JWTApi.Models;
using JWTApi.Dtos;
using Microsoft.EntityFrameworkCore;


namespace JWTApi.Data
{
    public class DataContext : DbContext

    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

// protected override void OnModelCreating(ModelBuilder moddheaita) 
// { 
//     moddheaita.Entity<Student>().HasKey(c => new { c.Registration, c. Student_Id }); 
//     // moddheaita.Entity<User>().HasKey(c => new { c.Registration, c. Student_Id }); 
// }
            public DbSet<Values> Values {get; set; }
            public DbSet<Staff> Staffs {get; set;}  
            public DbSet<Invertory> Invertories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Room> Rooms { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Transaction> Transactions { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Usertype> Usertypes { get; set; }    
            public DbQuery<InventoryDto> Inventory { get; set; }
            public DbQuery<Users> User {get; set; }
            public DbQuery<Staffs> Staff {get; set; }
            // // public DbQuery<transaction> Transaction {get; set; }


    
         
    }
}