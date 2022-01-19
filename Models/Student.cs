using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTApi.Models
{
    public class Student
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Key]
        public int Student_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
        public string DateOfBirth { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        
        public string Registration { get; set; }
        public string Session { get; set; }
        public string Department { get; set; }
        public string HallRoll { get; set; }
        public string StuffName { get; set; }

        public int? Room_Id { get; set; }
        [ForeignKey("Room_Id")]
        public Room Room { get; set; }

       public ICollection<User> User { get; set; }


    }
}
// <!--
//         registration: ['', Validators.required],
//         address: ['', Validators.required],
//         bloodGroup: ['', Validators.required],
//         dateOfBirth: ['', Validators.required],
//         department: ['', Validators.required],
//         fatherName: ['', Validators.required],
//         firstname: ['', Validators.required],
//         hallRoll: ['', Validators.required],
//         lastname: ['', Validators.required],
//         motherName: ['', Validators.required],
//         nationality: ['', Validators.required],
//         religion: ['', Validators.required],
//         session: ['', Validators.required],
//         stuffName: ['', Validators.required]
// -->