using DataBase;
using DataBase.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Employes.Controllers.API
{
    [ApiController]
    public class AttendanceRequestsController : ControllerBase
    {
        private readonly IUOW _db;
        public AttendanceRequestsController(IUOW db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("API/Attendance/GetByEmployeeId")]
        public dynamic GetByEmployeeId(int empId)
        {
            var emp = _db.EmployesRepo.GetById(empId);
            var logs = _db.AttendanceRepo.FindAll(a => a.EmployeId == empId).ToList().
                Select(a => new
                {
                    Name = emp.Name,
                    Code = emp.Code,
                    Date = a._Date.Date.ToString("dddd, dd MMMM yyyy"),
                    CheckIn = a.CheckInTime.TimeOfDay,
                    CheckOut = a.CheckOutTime.TimeOfDay,
                    TotalHours = ((TimeSpan)(a.CheckOutTime - a.CheckInTime)).TotalHours
                });
            return logs;
        }

        [HttpGet]
        [Route("API/Attendance/GetByDate")]
        public dynamic GetByEmployeeId(DateTime _date)
        {
            //var data = _db.AttendanceRepo.FindAll(a => a._Date.Date == _date.Date)
            //    .join(_db.EmployesRepo.GetAll(), a,,)
            HREntities db = new HREntities();
            var data = db.Attendance.Where(a => a._Date.Date == _date).Join(db.Employes,
                 a => a.EmployeId, emp => emp.Id, (a, emp) => new
                 {
                     Name = emp.Name,
                     Code = emp.Code,
                     Date = a._Date.Date.ToString("dddd, dd MMMM yyyy"),
                     CheckIn = a.CheckInTime.TimeOfDay,
                     CheckOut = a.CheckOutTime.TimeOfDay,
                     TotalHours = ((TimeSpan)(a.CheckOutTime - a.CheckInTime)).TotalHours
                 }).ToList();
            return data;
        }
    }
}
