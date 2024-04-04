using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Data.Entity
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("family_name")]
        public string FamilyName { get; set; }

        [Column("birth_date")]
        public DateTime Birthdate { get; set; }

        [Column("validated")]
        public bool Validated { get; set; }
    }
}
