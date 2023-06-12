using MC.PersistanceServices;
using MC.WebApi.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MC.WebApi.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace MC.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly MovieDbContext _context;
    private readonly TokenProvider _tokenService;

    public AuthController(UserManager<IdentityUser> userManager, MovieDbContext context, TokenProvider tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }


    [HttpPost]
    public async Task<ActionResult> Register(RegisterDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(
            new IdentityUser { UserName = request.Username, Email = request.Email },
            request.Password
        );
        if (result.Succeeded)
        {
            request.Password = "";
            return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpPost]
    public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByNameAsync(request.Username);

        if (managedUser is null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var accessToken = _tokenService.CreateToken(managedUser);
        await _context.SaveChangesAsync();

        return Ok(new TokenResponse
        {
            Username = managedUser.UserName,
            Email = managedUser.Email,
            Token = accessToken,
        });

    }

    [Authorize]
    [HttpGet("/GetMyId")]
    public async Task<ActionResult> GetUserId()
    {
        var id = User.FindFirst("UserId").Value;
        return Ok(id);
    }
}
