using Application.Services;
using Domain.WebApiModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginServices _loginServices;
        private int _retryAfterInSeconds;

        public LoginController(LoginServices loginServices)
        {
            _loginServices = loginServices;
            _retryAfterInSeconds = 5;
        }

        // POST api/<LoginController>
        [HttpPost]
        public ActionResult<LoginResponse> Post(LoginRequest loginRequest)
        {
            try
            {
                if (!loginRequest.IsValid())
                    return BadRequest("Невалидные данные");

                var token = _loginServices.LoginUser(loginRequest);
                if (token == null)
                    return NotFound("Пользователь не найден");
                return
                    Ok(token);
            }
            catch (Exception)
            {
                // 500 Ошибка сервера Retry-After Время, через которое еще раз нужно сделать запрос integer
                // todo Log error
                HttpContext.Response.Headers.Add("Retry-After", _retryAfterInSeconds.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
                        
            // todo если сервис не готов 503 Ошибка сервера Retry-After Время, через которое еще раз нужно сделать запрос integer
        }
    }
}
