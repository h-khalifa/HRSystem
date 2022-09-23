using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Employes.Models
{
    public class AttendanceViewModel
    {
        [Key]
        public int Id { get; set; }
        
        public int EmployeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime _Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime CheckInTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime CheckOutTime { get; set; }

        virtual public EmployeViewModel Employe { get; set; }
    }
}
