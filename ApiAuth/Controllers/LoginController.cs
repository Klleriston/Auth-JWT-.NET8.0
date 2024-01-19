using Microsoft.AspNetCore.Mvc;

namespace ApiAuth
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {   
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)

        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
            {
                return NotFound(new {message = "User not found"});
            }

            var token = TokenService.GenerateToken(user);

            //ocultar a senha:
            user.Password = "";

            return new 
            {
                user = user,
                token = token
            };
        }
    }

}
