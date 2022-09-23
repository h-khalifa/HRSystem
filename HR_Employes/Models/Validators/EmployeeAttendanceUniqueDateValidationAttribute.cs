using DataBase;
using DataBase.Entities;
using DataBase.Repositories;
using System.ComponentModel.DataAnnotations;

namespace HR_Employes.Models.Validators
{
    public class EmployeeAttendanceUniqueDateValidationAttribute : ValidationAttribute
    {
        //private readonly IUOW _db;
        //public EmployeeAttendanceUniqueDateValidationAttribute(IUOW db)
        //{
        //    _db = db;
        //}
        public string GetErrorMessage() =>
        "That employee has an attendance log on the same entered date!";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            ///no way for dependcy injection for unit of work object
            ///
            IUOW _db = new UOW(new DataBase.Entities.HREntities(), new BaseRepository<Employe>(), new BaseRepository<Attendance>());


            var log = (AttendanceViewModel)validationContext.ObjectInstance;
            var date = ((DateTime)value);

            var employee = _db.EmployesRepo.Find(emp => emp.Code == log.EmployeCode);

            if (employee != null)
            {
                var count = _db.AttendanceRepo.Count(a => a.EmployeId == employee.Id && a._Date.Date == date);
                if(count == 0)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(GetErrorMessage());
        }
    }
}
