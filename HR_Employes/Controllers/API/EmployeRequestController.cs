using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Employes.Controllers.API
{
    [ApiController]
    public class EmployeRequestController : ControllerBase
    {
        private readonly IUOW _db;
        public EmployeRequestController(IUOW db)
        {
            _db = db;
        }
        [Route("API/Employees/GetAll")]
        public dynamic GetAllEmployees()
        {
            var emps = _db.EmployesRepo.GetAll().Select(emp => new
            {
                Name = emp.Name,
                Id = emp.Id,
                Email = emp.Email,
                Manager = emp.Manager?.Name,
                Code = emp.Code,
            }).ToList();
            return emps;
        }
        [Route("API/Employees/GetAllByManager")]
        public dynamic GetAllEmployees(int ManagerId)
        {
            var emps = _db.EmployesRepo.FindAll(emp => emp.ManagerId == ManagerId).Select(emp => new
            {
                Name = emp.Name,
                Id = emp.Id,
                Email = emp.Email,
                //Manager = emp.Manager?.Name,
                Code = emp.Code,
            }).ToList();
            return emps;
        }
        [Route("API/Employees/GetManagers")]
        public dynamic GetAllManagers()
        {
            
            var managerIds = _db.EmployesRepo.FindAll(emp => emp.ManagerId != null).Select(emp => emp.ManagerId).ToList();
            var managers = _db.EmployesRepo.FindAll(emp => managerIds.Contains(emp.Id)).
                Select(emp => new
                {
                    Name = emp.Name,
                    Id = emp.Id,
                }).ToList();
            return managers;
        }
    }
}
