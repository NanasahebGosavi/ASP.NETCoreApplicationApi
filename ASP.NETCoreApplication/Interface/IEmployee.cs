using ASP.NETCoreApplication.Entities;

namespace ASP.NETCoreApplication.Interface
{
    public interface IEmployee
    {
        IEnumerable<Employee>GetAllEmpIEnumerable();
        IQueryable<Employee> GetAllEmpIQueryable();
        
        
    }
}
