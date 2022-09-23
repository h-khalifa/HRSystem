using System.ComponentModel.DataAnnotations;

namespace HR_Employes.Models
{
    public class EmployeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(1000, 9999)]
        public string? Code { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
       
        public int? ManagerId { get; set; }


        //navs
        virtual public EmployeViewModel Manager { get; set; }
        virtual public ICollection<AttendanceViewModel> Attendances { get; set; }
    }
}
