using DataBase;
using HR_Employes.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Employes.Controllers
{
    public class EmployesController : Controller
    {
        private readonly IUOW _db;
        public EmployesController(IUOW db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeViewModel EmpModel)
        {
            if (!ModelState.IsValid)
            {
                return View(EmpModel);
            }

            DataBase.Entities.Employe manager = null;
            if (!string.IsNullOrEmpty( EmpModel.ManagerCode))
            {
                manager = _db.EmployesRepo.Find(emp => emp.Code == EmpModel.ManagerCode);
            }
            
            _db.EmployesRepo.Add(new DataBase.Entities.Employe()
            {
                Address = EmpModel.Address,
                Name = EmpModel.Name,
                BirthDate = EmpModel.BirthDate,
                Code = EmpModel.Code,
                Email = EmpModel.Email,
                ManagerId = manager?.Id, 
                MobileNumber = EmpModel.MobileNumber
            });
            _db.Submit();

            return RedirectToAction(nameof(All));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateNewEmployeCode(string code)
        {
            var emp = _db.EmployesRepo.Find(emp => emp.Code == code);
            if (emp == null)
                return Json(true);
            else
                return Json("This code belongs to " + emp.Name);
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateExistingEmployeCode(string managerCode)
        {
            var emp = _db.EmployesRepo.Find(emp => emp.Code == managerCode);
            if (emp == null)
                return Json("Not Existing Employee.!");
            else
                return Json(true);

        }

        public IActionResult All()
        {
            return View();
        }
    }
}
