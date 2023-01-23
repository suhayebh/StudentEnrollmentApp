using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentEnrollment.API.DTOs.Authentication;
using StudentEnrollment.Data.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentEnrollment.API.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<SchoolUser> _userManager;
        private readonly IConfiguration _configuration;
        private SchoolUser _user;

        public AuthManager(UserManager<SchoolUser> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResponseDTO> Login(LoginDTO model)
        {
            _user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (_user is null) return default;
            bool isValidCred = await _userManager.CheckPasswordAsync(_user, model.Password);
            if (!isValidCred) return default;

            var token = await GenerateTokenAsync();
            return new AuthResponseDTO() { Token = token, UserId = _user.Id };
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterDTO model)
        {
            _user = new SchoolUser()
            {
                DateOfBirth = model.DateOfBirth,
                Email = model.EmailAddress,
                UserName = model.EmailAddress,
                FirstName= model.FirstName,
                LastName= model.LastName
            };

            var result = await _userManager.CreateAsync(_user, model.Password);
            if(result.Succeeded) await _userManager.AddToRoleAsync(_user, "User");
            return result.Errors;
        }

        private async Task<string> GenerateTokenAsync()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credntials = new SigningCredentials (securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("userId", _user.Id)
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Int32.Parse(_configuration["JwtSettings:DurationInHours"].ToString())),
                signingCredentials: credntials
                ) ;
            return new JwtSecurityTokenHandler().WriteToken(token) ;
        }
    }
}
