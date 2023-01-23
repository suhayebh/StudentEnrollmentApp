using Microsoft.AspNetCore.Identity;
using StudentEnrollment.API.DTOs.Authentication;

namespace StudentEnrollment.API.Services
{
    public interface IAuthManager
    {
        Task<AuthResponseDTO> Login(LoginDTO login);
        Task<IEnumerable<IdentityError>> Register(RegisterDTO model);
    }
}
