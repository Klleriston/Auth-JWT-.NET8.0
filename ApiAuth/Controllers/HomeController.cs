using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers;  
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => $"Welcome, {User.Identity.Name}";

    [HttpGet]
    [Route("sourcer")]
    [Authorize(Roles = "Special,B")]
    public string Soucer() => "Jujutsu Source";

    [HttpGet]
    [Route("special")]
    [Authorize(Roles = "Special")]
    public string SSS() => "Welcome Satoro.";

    
}