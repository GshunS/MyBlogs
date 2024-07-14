using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyBlog.JWT.Utils._MD5;
using MyBlog.JWT.Utils.ApiResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;


namespace MyBlog.JWT.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorService _IAuthorService;
    public AuthorizationController(IAuthorService _iAuthorService)
    {
        this._IAuthorService = _iAuthorService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ApiResult>> Login(string username, string password)
    {
        string pwd = MD5Helper.MD5Encrypt32(password);

        var author = await _IAuthorService.FindAsync(c => c.AccountNumber == username && c.Password == pwd);

        if (author != null)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, author.Name),
                new Claim("Id", author.Id.ToString()),
                new Claim("AccountNumber", author.AccountNumber)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VFKSDK"));
            //issuer代表颁发Token的Web应用程序，audience是Token的受理者
            var token = new JwtSecurityToken(
                issuer: "http://localhost:6060",
                audience: "http://localhost:7146",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return ApiResultHelper.Success(jwtToken);
        }
        return ApiResultHelper.Error("username or password is incorrect!");
    }
}
