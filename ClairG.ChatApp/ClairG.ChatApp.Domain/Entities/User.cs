using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClairG.ChatApp.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(5), Index(IsUnique =true), Column(TypeName="VARCHAR")]
        public string Username { get; set; }

        [Required, MinLength(5), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, EmailAddress, Index(IsUnique =true), Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string ImageUrl { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDateTime { get; set; }
    }
}
