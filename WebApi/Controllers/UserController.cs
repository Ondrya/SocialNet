using Application.Services;
using Domain.WebApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        private int _retryAfterInSeconds;

        public UserController(UserService userService)
        {
            _userService = userService;
            _retryAfterInSeconds = 5;
        }


        // GET api/<UserController>/5
        [HttpGet("get/{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                bool isValid = Guid.TryParse(id, out var guidOutput);
                if (!isValid)
                    return BadRequest("Невалидные данные");

                Profile? profile = _userService.Get(guidOutput);
                if (profile == null)
                    return NotFound("Пользователь не найден");
                return
                    Ok(profile);
            }
            catch (Exception ex)
            {
                // 500 Ошибка сервера Retry-After Время, через которое еще раз нужно сделать запрос integer
                // todo Log error
                HttpContext.Response.Headers.Add("Retry-After", _retryAfterInSeconds.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            // todo если сервис не готов 503 Ошибка сервера Retry-After Время, через которое еще раз нужно сделать запрос integer
        }

        // POST api/<UserController>
        [HttpPost("register")]
        public ActionResult<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
