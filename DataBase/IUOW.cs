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
    public interface IUOW
    {
        IBaseRepository<Employe> EmployesRepo { get; }
        IBaseRepository<Attendance> AttendanceRepo { get; }

        int Submit();

        DbContext _ctx { get; }
    }
}
