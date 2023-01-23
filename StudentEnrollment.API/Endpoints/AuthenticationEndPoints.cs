using AutoMapper;
using Azure;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using StudentEnrollment.API.DTOs.Authentication;
using StudentEnrollment.API.DTOs.Course;
using StudentEnrollment.API.DTOs.Generic;
using StudentEnrollment.API.Services;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentEnrollment.API.Endpoints
{
    public static class AuthenticationEndPoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/auth").WithTags("Authentication");

            group.MapPost("/login", async Task<Results<Ok<AuthResponseDTO>, BadRequest>> (LoginDTO model, IAuthManager authManager) =>
            {
                var response = await authManager.Login(model);
                return response == null ? TypedResults.BadRequest() : TypedResults.Ok(response);
            })
            .AddEndpointFilter(async (context, next) =>
            {
                //check if the return type result doesnt really apply here
                var loginDTO = context.GetArgument<LoginDTO>(0);
                LoginDTOValidator validator = new LoginDTOValidator();
                var validationResult = await validator.ValidateAsync(loginDTO);
                if (!validationResult.IsValid)
                    return TypedResults.BadRequest(validationResult.Errors);
                return await next(context);
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

        private static List<ErrorResponseDTO> ToErrorDTOList(List<ValidationFailure> errors)
        {
            var errorList = new List<ErrorResponseDTO>();
            foreach (var error in errors)
            {
                errorList.Add(new ErrorResponseDTO { Code = error.ErrorCode, Description = error.ErrorMessage });
            }
            return errorList;
        }
    }
}
