using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentEnrollment.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "497c1755-f3c2-4ec8-98d2-e05e03dd2bf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9dfe70c-6526-47bf-9ef7-88e2586c9011");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b43c232-78c5-4640-8bec-c493890ff874", null, "Administrator", "ADMINISTRATOR" },
                    { "8bcedbe7-efb9-4dbe-abdb-5c72c13eecf4", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21bd9497-94f6-484b-b3a9-f59d5c9e1efb", 0, "3da7e513-7a6a-40ce-ad10-76117c415fe5", null, "principle@school.ae", false, "Suha", "ScPickkles", false, null, "PRINCIPLE@SCHOOL.AE", "PRINCIPLE@SCHOOL.AE", "AQAAAAIAAYagAAAAECEzGW1J8l/KrdR13JNWrF0fc+08jrcQZpNWbQOd1hRFvb2juiJWewOIlJslsZBPbg==", null, false, "73c7751a-d412-43f0-968d-b6658856aebe", false, "principle@school.ae" },
                    { "9db11d1c-8493-4279-9dd7-0b346a3f7f77", 0, "3276c310-d4a9-4dfc-a7b2-618ddeb0aa58", null, "admin@school.ae", false, "Sean", "ScPickkle", false, null, "ADMIN@SCHOOL.AE", "ADMIN@SCHOOL.AE", "AQAAAAIAAYagAAAAEESXTosrinWnW7O/p/jQw+2TLwKQLuc2azvGoxK2nJ1SE6J6KA4Y1P8HHDSzD345Yw==", null, false, "d680cb2e-0bea-4e22-8c43-49f313ee13f4", false, "admin@school.ae" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8bcedbe7-efb9-4dbe-abdb-5c72c13eecf4", "21bd9497-94f6-484b-b3a9-f59d5c9e1efb" },
                    { "4b43c232-78c5-4640-8bec-c493890ff874", "9db11d1c-8493-4279-9dd7-0b346a3f7f77" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8bcedbe7-efb9-4dbe-abdb-5c72c13eecf4", "21bd9497-94f6-484b-b3a9-f59d5c9e1efb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b43c232-78c5-4640-8bec-c493890ff874", "9db11d1c-8493-4279-9dd7-0b346a3f7f77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b43c232-78c5-4640-8bec-c493890ff874");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bcedbe7-efb9-4dbe-abdb-5c72c13eecf4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21bd9497-94f6-484b-b3a9-f59d5c9e1efb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9db11d1c-8493-4279-9dd7-0b346a3f7f77");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "497c1755-f3c2-4ec8-98d2-e05e03dd2bf1", null, "User", "USER" },
                    { "c9dfe70c-6526-47bf-9ef7-88e2586c9011", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
