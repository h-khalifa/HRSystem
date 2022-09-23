using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Employe
    {

        [Key]
        public int Id { get; set; }
        [Required, Range(1000, 9999)]
        public string? Code { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }


        //navs
        virtual public Employe Manager { get; set; }
        virtual public ICollection<Attendance> Attendances { get; set; }

    }
}
