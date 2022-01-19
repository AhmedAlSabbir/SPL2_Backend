using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWTApi.Models
{
    public class Usertype
    {
        [Key]
        public int UserId { get; set; }
        public int Dasignation { get; set; }

        public ICollection<User> User { get; set; }

    }
}