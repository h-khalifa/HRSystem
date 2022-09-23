using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HR_Employes.Models
{
    public class EmployeViewModel
    {
        [Required, Range(1000, 9999)]
        [Remote(action: "ValidateNewEmployeCode", controller: "Employes")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        [Display(Name = "Birth Day")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number.")]
        [RegularExpression(@"^([0-9]{8,11})$", ErrorMessage = "Invalid Phone Number! only digits of length between 8 and 11")]
        [Display(Name ="Phone")]
        public string MobileNumber { get; set; }
        [Remote(action: "ValidateExistingEmployeCode", controller: "Employes")]
        [Display(Name ="Manager Code")]
        public string? ManagerCode { get; set; }


        //navs
        ////virtual public EmployeViewModel Manager { get; set; }
        //virtual public ICollection<AttendanceViewModel> Attendances { get; set; }
    }
}
