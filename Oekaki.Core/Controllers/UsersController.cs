using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oekaki.Core.Domains;
using Oekaki.Data;
using Oekaki.Data.Models;
using Oekaki.Shared.Extensions;

namespace Oekaki.Core.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public UsersController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    /// <summary>
    /// Due to complications with Identity, I found easier to just
    /// register an alternative endpoint to create the account.
    /// Over time may end up just replacing all of MapIdentityApi()'s
    /// default endpoints.
    /// </summary>
    /// <param name="register">The body of the request</param>
    [HttpPost("signup")]
    public async Task<ActionResult<UserDto>> Register([FromBody] Register register)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        User user = new()
        {
            UserName = register.UserName,
            Email = register.Email,
            Nickname = register.Nickname,
            URISlug = register.Nickname.Slugify(),
        };

        IdentityResult result = await _userManager.CreateAsync(user, register.Password);

        if (result.Succeeded)
        {
            // Ensuring the first registered user will be an admin
            // if (!_context.Users.Any())
            // {
            //     if (!await _roleManager.RoleExistsAsync("Admin"))
            //     {
            //         await _roleManager.CreateAsync(new IdentityRole("Admin"));
            //     }

            //     await _userManager.AddToRoleAsync(user, "Admin");
            // }

            _context.EnsureUniqueURISlugs();
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.Nickname,
                    user.URISlug,
                }
            );
        }

        foreach (IdentityError error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return ValidationProblem(ModelState);
    }

    // GET: /Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        List<UserDto> users = await _context
            .Users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Nickname = user.Nickname,
                URISlug = user.URISlug,
            })
            .ToListAsync();

        return Ok(users);
    }

    // GET: /Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(string id)
    {
        UserDto? user = await _context
            .Users.Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Nickname = u.Nickname,
                URISlug = u.URISlug,
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // GET: /Users/me
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserProtectedDto>> GetLoggedInUser()
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        UserProtectedDto? user = await _context
            .Users.Where(u => u.Id == userId)
            .Select(u => new UserProtectedDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Nickname = u.Nickname,
                URISlug = u.URISlug,
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // POST: /Users/logout
    [HttpPost("logout")]
    [Authorize]
    public async Task<ActionResult> Logout(SignInManager<User> manager, [FromBody] object empty)
    {
        if (empty != null)
        {
            await manager.SignOutAsync();

            return Ok();
        }

        return Unauthorized();
    }
}
