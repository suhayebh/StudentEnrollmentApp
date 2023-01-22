using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Models;
using StudentEnrollment.Data.Contracts;
using AutoMapper;
using StudentEnrollment.API.DTOs.Enrollment;

namespace StudentEnrollment.API.Endpoints;

public static class EnrollmentEndpoints
{
    public static void MapEnrollmentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollment").WithTags(nameof(Enrollment));

        //GetAll
        group.MapGet("/", async (IEnrollmentRespository repo, IMapper mapper) =>
        {
            return mapper.Map<List<EnrollmentDTO>>(await repo.GetAllAsync());
        })
        .WithName("GetAllEnrollments")
        .WithOpenApi();

        //Get{id}
        group.MapGet("/{id}", async Task<Results<Ok<EnrollmentDTO>, NotFound>> (int id, IEnrollmentRespository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Enrollment model
                    ? TypedResults.Ok(mapper.Map<EnrollmentDTO>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetEnrollmentById")
        .WithOpenApi();

        //Put
        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, EnrollmentDTO model, IEnrollmentRespository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);
            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            mapper.Map(model, foundModel);
            await repo.UpdateAsync(foundModel);

            return TypedResults.NoContent();
        })
        .WithName("UpdateEnrollment")
        .WithOpenApi();

        //Post
        group.MapPost("/", async (CreateEnrollmentDTO model, IEnrollmentRespository repo, IMapper mapper) =>
        {
            var enrollment = await repo.CreateAsync(mapper.Map<Enrollment>(model));
            return TypedResults.Created($"/api/Enrollment/{enrollment.Id}", enrollment);
        })
        .WithName("CreateEnrollment")
        .WithOpenApi();

        //Del
        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, IEnrollmentRespository repo, IMapper mapper) =>
        {
            return await repo.DeleteAsync(id) ? TypedResults.Ok() : TypedResults.NotFound();

        })
        .WithName("DeleteEnrollment")
        .WithOpenApi();
    }
}
