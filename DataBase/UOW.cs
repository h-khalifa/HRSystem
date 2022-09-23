using DataBase.Entities;
using DataBase.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class UOW : IUOW
    {
        public IBaseRepository<Employe> EmployesRepo { get; }
        public IBaseRepository<Attendance> AttendanceRepo { get; }

        public DbContext _ctx { get; private set; }

        public UOW(HREntities CTX,
            IBaseRepository<Employe> employeRepository,
            IBaseRepository<Attendance> attendanceRepository
            )
        {
            _ctx = CTX;

            EmployesRepo = employeRepository;
            AttendanceRepo = attendanceRepository;


            EmployesRepo.SetContext(_ctx);
            AttendanceRepo.SetContext(_ctx);
        }

        public int Submit()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
