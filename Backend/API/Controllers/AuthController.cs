using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using APP.Auth;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] Dtos.LoginRequest request)
        {

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username y Password son requeridos.");
            }

            var authResult = await _authService.AuthenticateAsync(request.Username, request.Password);

            if (!authResult.Success)
            {
                return Unauthorized("Credenciales inválidas");
            }

            return Ok(new { Token = authResult.Token, RefreshToken = authResult.RefreshToken });
        }

        [HttpGet("token-info")]
        public IActionResult GetTokenInfo()
        {
            // Obtén información sobre el token actualmente autenticado
            var username = User.Identity.Name; // Puedes acceder al nombre de usuario así si se incluyó en el token

            // Puedes incluir más detalles sobre el token si es necesario
            var tokenInfo = new
            {
                Username = username,
                ExpiryDate = User.FindFirst("exp")?.Value // Ejemplo de cómo obtener la fecha de vencimiento desde el token
                // Agrega más información según tus necesidades
            };

            return Ok(tokenInfo);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            // Lógica para registrar al usuario en UserService
            var registrationResult = await _userService.RegisterAsync(request.Email, request.Password);

            if (!(registrationResult is bool success) || !success)
            {
                // Manejar el error de registro, por ejemplo, devolver un BadRequest
                return BadRequest("Error al registrar al usuario.");
            }

            // El usuario se registró exitosamente
            return Ok("Registro exitoso.");
        }
    }
}