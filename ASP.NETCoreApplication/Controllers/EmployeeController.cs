using ASP.NETCoreApplication.Entities;
using ASP.NETCoreApplication.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeservice;
        public EmployeeController(IEmployee employeeservice)
        {
            //test code
            _employeeservice = employeeservice;

        }
        // GET: api/<EmployeeController>
        [HttpGet("GetAllIEnumerable")] 

       public ActionResult <IEnumerable<Employee>> GetAllEmpIEnumerable()
       {
            var res = _employeeservice.GetAllEmpIEnumerable();
            return Ok(res);
       }
        [HttpPost ("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file )
        {
            string strFileName = file.Name;

            return Ok(strFileName);
        }

        [HttpGet("GetAllIQurable")]

        public ActionResult<IQueryable<Employee>> GetAllIQurable()
        {
            var res = _employeeservice.GetAllEmpIQueryable();
            return Ok(res);
        }

        
    }
}
