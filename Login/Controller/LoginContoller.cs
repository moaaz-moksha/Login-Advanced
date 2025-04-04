using Login.Dtos;
using Login.Repositoryes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginContoller : ControllerBase
    {
        private readonly ILoginRepo _repo;
        public LoginContoller(ILoginRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult Add(Logindto logindto)
        {
            var res = _repo.Add(logindto);
            if (res != false)
            {
                return Ok(res + "" + logindto.email + "" + "" + logindto.password);
            }
            return BadRequest(res);
        }
        [HttpPost("login")]
        public IActionResult Login(Logindto0 logindto)
        {
            if (_repo.SearchOfuser(logindto))
            {
                return Ok(new { message = "تم تسجيل الدخول بنجاح ✅" });
            }
            else
            {
                return Unauthorized(new { message = "الإيميل أو الباسورد غير صحيح ❌" });
            }

        }
        [HttpGet]
        public IActionResult GetAll(String role)
        {
            var res = _repo.GetALL(role);
            if(res != null)
            {
                return Ok(res);
            }
            return BadRequest();
           
        }
    }
}
