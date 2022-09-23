using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime _Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime CheckInTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime CheckOutTime { get; set; }

        virtual public Employe Employe { get; set; }
    }
}
