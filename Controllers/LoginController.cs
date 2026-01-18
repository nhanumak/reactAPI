using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using React_API.Interface.Security;
using React_API.Models;
using System.Collections.Concurrent;
using System.Security.Claims;

namespace React_API.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITokenServiceRepository _tokenService;

        // Simple in-memory store for refresh tokens (username -> refreshToken).
        // Replace with a DB-backed store for production.
        private static readonly ConcurrentDictionary<string, string> _refreshTokens = new();

        public LoginController(IConfiguration config, ITokenServiceRepository tokenService)
        {
            _config = config;
            _tokenService = tokenService;
        }

        [HttpPost("api/login")]
        public IActionResult Login([FromBody] UserCredentialDetails request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // TODO: Replace this simple check with real credential validation against your user store.
            // For now we accept any non-empty username/password pair.
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.UserName) };

            var accessToken = _tokenService.GenerateAccessToken(claims, _config);
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Save refresh token in memory store (or DB in real app)
            SaveRefreshToken(request.UserName, refreshToken);

            return Ok(new { accessToken, refreshToken });
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] UserCredentialDetails request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest("Username and refreshToken are required.");
            }

            var storedToken = GetRefreshToken(request.UserName);
            if (storedToken is null || storedToken != request.RefreshToken)
            {
                return Unauthorized();
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.UserName) };
            var newAccessToken = _tokenService.GenerateAccessToken(claims, _config);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            UpdateRefreshToken(request.UserName, newRefreshToken);

            return Ok(new { accessToken = newAccessToken, refreshToken = newRefreshToken });
        }

        // --- Simple token store helper methods ---

        private string? GetRefreshToken(string username)
        {
            return _refreshTokens.TryGetValue(username, out var token) ? token : null;
        }

        private void SaveRefreshToken(string username, string refreshToken)
        {
            _refreshTokens[username] = refreshToken;
        }

        private void UpdateRefreshToken(string username, string newRefreshToken)
        {
            _refreshTokens[username] = newRefreshToken;
        }

        //// --- DTOs (kept as nested types to keep file self-contained) ---

        //public sealed record LoginRequest(string Username, string Password);

        //public sealed record RefreshRequest(string Username, string RefreshToken);
    }
}
