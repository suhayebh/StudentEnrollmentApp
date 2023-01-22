using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Models;
using StudentEnrollment.API.DTOs.Course;
using AutoMapper;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.API.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Course").WithTags(nameof(Course));

        //GetAll
        group.MapGet("/", async (ICourseRepository repo, IMapper mapper) =>
        {
            var courses = await repo.GetAllAsync();
            return mapper.Map<List<CourseDTO>>(courses);
        })
        .WithName("GetAllCourses")
        .WithOpenApi();

        //Get{id}
        group.MapGet("/{id}", async Task<Results<Ok<CourseDTO>, NotFound>> (int id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Course model
                    ? TypedResults.Ok(mapper.Map<CourseDTO>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseById")
        .WithOpenApi();

        //GetStudents{id}
        group.MapGet("/GetStudents/{id}", async Task<Results<Ok<CourseDetailsDTO>, NotFound>> (int id, ICourseRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentList(id)
                is Course model
                    ? TypedResults.Ok(mapper.Map<CourseDetailsDTO>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetCourseDetailsById")
        .WithOpenApi();

        //Put{id}
        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, CourseDTO course, ICourseRepository repo, IMapper mapper) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            mapper.Map(course, foundModel);
            await repo.UpdateAsync(foundModel);

            return TypedResults.NoContent();
        })
        .WithName("UpdateCourse")
        .WithOpenApi();

        //Post{new}
        group.MapPost("/", async (CreateCourseDTO model, ICourseRepository repo, IMapper mapper) =>
        {
            var course = mapper.Map<Course>(model);
            await repo.CreateAsync(course);
            // you can change to DTO
            return TypedResults.Created($"/api/Course/{course.Id}", course);
        })
        .WithName("CreateCourse")
        .WithOpenApi();

        //Del{id}
        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ICourseRepository repo ) =>
        {
            return await repo.DeleteAsync(id) ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCourse")
        .WithOpenApi();
    }
}
