using DemoDotnetWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoDotnetWebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PasswordController : ControllerBase
{
    private readonly ILogger<PasswordController> _logger;
    private readonly IPasswordGenerator _passwordGenerator;

    public PasswordController(ILogger<PasswordController> logger, IPasswordGenerator passwordGenerator)
    {
        _logger = logger;
        _passwordGenerator = passwordGenerator;
    }

    [HttpGet]
    public string Get()
    {
        return _passwordGenerator.Generate();
    }
}
