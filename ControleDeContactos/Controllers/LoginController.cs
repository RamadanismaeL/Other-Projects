using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ControleDeContactos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginController> _logger;
        private const string keyRam = "9c6d5d2983b7fab36afea72639222fe6958cb8c2289d2739f630d859e5644963712c6b1279020bca3c62088fb18902354ca96231e182a0c21cc9a0f37c7ca3fe";
        public LoginController(IUserRepository userRepository, ILogger<LoginController> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger = logger;
        }
        private static string GenerateToken(UserModel user)
        {
            if (user.UserName == null)
            {
                throw new ArgumentException("User or Username cannot be null", nameof(user));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyRam));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512); // Header

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                //new Claim("login", "admin"),
                new Claim("nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken(
                issuer: "Ismael_Business_Solution", /* Deve ser o mesmo nome ISSUER que está no Program.cs */
                audience: "Controle_De_Contactos", /* Aqui também */
                claims: claims, /* Payload -- dados do usuário para ter acesso*/
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            try
            {
                if (login == null || string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password)) return BadRequest(new { mensagem = "Invalid login request. Please check your input." });
                var user = _userRepository.FindByUsername(login.UserName);
                if (user == null || !user.ValidPassword(login.Password)) return Unauthorized(new { message = "Invalid credentials. Please check your username and password." });

                var token = GenerateToken(user);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}