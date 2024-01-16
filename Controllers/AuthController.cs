using Microsoft.AspNetCore.Mvc;
using RuRuServer.Models;

namespace RuRuServer.Controllers;


[ApiController]
public class AuthController : ControllerBase
{
    private static Random random = new Random();
    public AuthController()
    {

    }

    [HttpGet]
    [Route("auth/new")]
    public Token CreateToken()
    {
        Console.WriteLine("Token requested");
        Token token = new Token
        {
            AccessToken = RandomString(96),
            RefreshToken = RandomString(96),
            ExpiresIn = 600,
            TokenType = "Bearer"
        };
        return token;
    }


    [HttpPost]
    [Route("auth/token")]
    public Token CreateToken(AuthRequest model)
    {
        Console.WriteLine("Token requested");
        Token token = new Token
        {
            AccessToken = RandomString(96),
            RefreshToken = RandomString(96),
            ExpiresIn = 600,
            TokenType = "Bearer"
        };
        return token;
    }

    private static string RandomString(int length)
    {
        
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}