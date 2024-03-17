using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;

namespace ExaminationSystemITI.Services
{
    public class DepartmentService : IDepartmentService
    {
        ApplicationDbContext _dbcontext;
        public DepartmentService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Department> GetDepartments()
        {
            var departments = _dbcontext.Departments.FromSqlRaw("EXEC SelectAllDepartments").ToList();           
            return departments;
        }

        public void DeleteDepartment(int id)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC DeleteDepartmentById {id}");
        }

        public void EditDepartment(Department dep)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC EditDepartmentById {dep.Id},{dep.Name},{dep.Branch}");
        }
       
        public void InsertDepartment(Department dep)
        {
            _dbcontext.Database.ExecuteSqlInterpolated($"EXEC InsertDepartment {dep.Name},{dep.Branch},{dep.SP}");
        }

        public Department FindDepartment(int id)
        {
            var department = _dbcontext.Departments.Find(id);
            return department;
        }
    }
}