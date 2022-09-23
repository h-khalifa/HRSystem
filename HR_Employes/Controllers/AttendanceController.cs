using DataBase;
using HR_Employes.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Employes.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IUOW _db;
        public AttendanceController(IUOW db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RecordAttendance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RecordAttendance(AttendanceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            
            var employee = _db.EmployesRepo.Find(emp => emp.Code == viewModel.EmployeCode);
            _db.AttendanceRepo.Add(new DataBase.Entities.Attendance()
            {
                EmployeId = employee.Id,
                CheckInTime = viewModel.CheckInTime,
                CheckOutTime = viewModel.CheckOutTime,
                _Date = viewModel._Date
            });
            _db.Submit();


            return RedirectToAction(nameof(Index));
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateCheckTimes(DateTime CheckInTime, DateTime CheckOutTime)
        {
            if(CheckInTime < CheckOutTime)
            {
                return Json(true);
            }
            else
            {
                return Json("Check in have to be earlier than check out");
            }
        }
        public IActionResult ValidateExistingEmployeCode(string EmployeCode)
        {
            var emp = _db.EmployesRepo.Find(emp => emp.Code == EmployeCode);
            if (emp == null)
                return Json("Not Existing Employee.!");
            else
                return Json(true);

        }
    }
}
