using ASP.NETCoreApplication.Context;
using ASP.NETCoreApplication.Entities;
using ASP.NETCoreApplication.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreApplication.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
       

      public  IEnumerable<Employee> GetAllEmpIEnumerable()
      {
            return _context.Employees.ToList();
      }

       public  IQueryable<Employee> GetAllEmpIQueryable()
       {
            return _context.Employees.AsQueryable();
       }


    }
}
