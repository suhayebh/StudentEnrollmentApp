using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using StudentEnrollment.Data;
using StudentEnrollment.Data.Models;
using AutoMapper;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.API.Services;

namespace StudentEnrollment.API.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        //GetAll
        group.MapGet("/", async (IStudentRepository repo, IMapper mapper) =>
        {
            return mapper.Map<List<StudentDTO>>(await repo.GetAllAsync());
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        //Get{id}
        group.MapGet("/{id}", async Task<Results<Ok<StudentDTO>, NotFound>> (int id,IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetAsync(id)
                is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDTO>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        //GetCourses{id}
        group.MapGet("/GetCourses/{id}", async Task<Results<Ok<StudentDetailsDTO>, NotFound>> (int id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.GetStudentDetails(id)
                is Student model
                    ? TypedResults.Ok(mapper.Map<StudentDetailsDTO>(model))
                    : TypedResults.NotFound();
        })
        .WithName("GetCoursesByStudentId")
        .WithOpenApi();

        //Put{id}
        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, StudentDTO student, IStudentRepository repo, IMapper mapper, IFileUpload upload) =>
        {
            var foundModel = await repo.GetAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            mapper.Map(student, foundModel);

            if(student.ProfilePicture != null)
                foundModel.Pitcure = upload.UploadFile(student.ProfilePicture, student.ProfilePictureUrl); //doesnt handle replacement

            await repo.UpdateAsync(foundModel);

            return TypedResults.NoContent();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();


        //Post{new}
        group.MapPost("/", async (StudentDTO model, IStudentRepository repo, IMapper mapper, IFileUpload upload) =>
        {
            //validation here
            var student = mapper.Map<Student>(model);
            student.Pitcure = upload.UploadFile(model.ProfilePicture, model.ProfilePictureUrl);
            await repo.CreateAsync(student);
            return TypedResults.Created($"/api/Student/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        //Del{id}
        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, IStudentRepository repo, IMapper mapper) =>
        {
            return await repo.DeleteAsync(id) ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
