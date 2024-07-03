using Aplicacao;
using Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(LoginService servicoLogin) : ControllerBase
    {
        private readonly LoginService _servicoLogin = servicoLogin;

        [HttpPost("login")]
        public OkObjectResult Login([FromBody] LoginDto login)
        {
            var retorno = _servicoLogin.Login(login);
            return Ok(retorno);
        }
    }
}

