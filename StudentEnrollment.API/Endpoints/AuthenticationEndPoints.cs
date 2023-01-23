using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using StudentEnrollment.API.DTOs.Authentication;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Generic;
using StudentEnrollment.API.Services;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Models;

namespace StudentEnrollment.API.Endpoints
{
    public static class AuthenticationEndPoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/auth").WithTags("Authentication");

            group.MapPost("/login", async Task<Results<Ok<AuthResponseDTO>, UnauthorizedHttpResult>> (LoginDTO model, IAuthManager authManager) =>
            {
                var response = await authManager.Login(model);
                return response == null ? TypedResults.Unauthorized() : TypedResults.Ok(response);
            })
            .WithName("Login")
            .WithOpenApi()
            .AllowAnonymous();

            group.MapPost("/register", async Task<Results<Ok, BadRequest<List<ErrorResponseDTO>>>> (RegisterDTO model, IAuthManager authManager) =>
            {
                var response = await authManager.Register(model);
                if (!response.Any()) return TypedResults.Ok();
                var errors = new List<ErrorResponseDTO>();
                foreach (var error in response) errors.Add(new ErrorResponseDTO { Code = error.Code, Description = error.Code });
                return TypedResults.BadRequest(errors);
            })
            .WithName("Register")
            .WithOpenApi()
            .AllowAnonymous();
        }

    }
}
