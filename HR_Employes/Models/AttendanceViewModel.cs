using HR_Employes.Models.Validators;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Employes.Models
{
    public class AttendanceViewModel
    {
        [Display(Name ="Employee Code")]
        [Required, Range(1000, 9999)]
        [Remote(action: "ValidateExistingEmployeCode", controller: "Attendance")]
        public string EmployeCode { get; set; }
        //public int EmployeId { get; set; }
        [DataType(DataType.Date), Required, Display(Name ="Attendance Date")]
        [AttendanceDateValidationAttribute]
        [EmployeeAttendanceUniqueDateValidationAttribute]
        public DateTime _Date { get; set; }
        [Remote(action: "ValidateCheckTimes", controller: "Attendance", AdditionalFields = nameof(CheckOutTime))]
        [DataType(DataType.Time), Required]
        [Display(Name = "Check-In Time")]
        public DateTime CheckInTime { get; set; }
        [DataType(DataType.Time), Required]
        [Remote(action: "ValidateCheckTimes", controller: "Attendance", AdditionalFields = nameof(CheckInTime))]
        [Display(Name = "Check-Out Time")]
        public DateTime CheckOutTime { get; set; }

        //virtual public EmployeViewModel Employe { get; set; }
    }
}
