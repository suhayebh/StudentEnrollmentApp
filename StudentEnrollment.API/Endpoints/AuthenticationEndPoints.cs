using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Models;

namespace StudentEnrollment.API.Endpoints
{
    public static class AuthenticationEndPoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/auth").WithTags("Authentication");

            group.MapPost("/login", async Task<Results<NotFound, Ok>> (LoginDTO model, UserManager<SchoolUser> userManager) =>
            {
                var user = await userManager.FindByEmailAsync(model.Username);
                if (user is null)
                    return TypedResults.NotFound();
                bool isValidCred = await userManager.CheckPasswordAsync(user, model.Password);
                if(!isValidCred)
                    return TypedResults.NotFound();
                //Generate Token
                return TypedResults.Ok();
            })
            .WithName("Login")
            .WithOpenApi();
        }

    }

    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
