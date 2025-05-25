using ASP.NETCoreApplication.Entities;
using ASP.NETCoreApplication.Helpers;
using ASP.NETCoreApplication.Interface;
using ASP.NETCoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;

            LinqExample linq = new LinqExample();
            // linq.FindLinq();
            // linq.TackLinqMethod();
            //linq.SkipLinqMethod();
            //linq.FirstLinqMethod();
            // linq.FirstOrDefaultLinqMethod();
            //linq.SingleLinqMethod();
            // linq.SingleOrDefaultLinqMethod();
            //linq.AnyLinqMethod();
            //linq.AllLinqMethod();
            //linq.CountLinqMethod();
            //linq.SumAverageLinqMethod();
            // linq.DistinctLinqMethod();
            // linq.UnionIntersectExceptLinqMethod();
            //linq.InnerLinqMethod();
            //linq.RightLinqMethod();
            // linq.LeftLinqMethod();
            //linq.InnerLinqMethodSyntacx();
            /* int  n = Convert.ToInt32(Console.ReadLine());
              linq.GetNThHigherSalary(n);*/

            linq.OrderNotification (OrderStetus.processing);



           /* string str = "welcome India";
            int cnt = str.WordCount();*/

        }

        
        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            var users = await _userservice.GetAll();
            return Ok(users);
        }

       
        [HttpGet("{id}")]
      
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userservice.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User userObj)
        {
            userObj.Id = 0;
            return Ok(await _userservice.AddAndUpdateUser(userObj));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] User userObj)
        {
            return Ok(await _userservice.AddAndUpdateUser(userObj));
        }


      [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _userservice.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
