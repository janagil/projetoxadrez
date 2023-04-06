using Microsoft.AspNetCore.Mvc;

namespace ProjetoXadrez.API.Controllers;

[ApiController]
[Route("[controller]")]

public class JogoXadrezController : ControllerBase
{
    private readonly ILogger<JogoXadrezController> _logger;
    public JogoXadrezController(ILogger<JogoXadrezController> logger)
    {
        _logger = logger;
    }
}
