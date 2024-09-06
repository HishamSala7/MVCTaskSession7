using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_Task2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<float>(type: "real", nullable: false),
                    MinDegree = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<float>(type: "real", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResults_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResults_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 100f, 60f, "Database" },
                    { 2, 120f, 70f, "Software Engineering" },
                    { 3, 150f, 100f, "Math" },
                    { 4, 80f, 65f, "C# Fundamentals" },
                    { 5, 100f, 55f, "Web Fundamentals" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Ali", "IT" },
                    { 2, "Raouf", "SWE" },
                    { 3, "Hassan", "IS" },
                    { 4, "Moataz", "DS" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "Grade", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, "Giza", 150f, "1.jpg", "Abdo" },
                    { 2, "Cairo", 180f, "2.jpg", "Omar" },
                    { 3, "Alex", 200f, "3.jpg", "Khaled" },
                    { 4, "Aswan", 120f, "4.jpg", "Loay" },
                    { 5, "Maadi", 115f, "1.jpg", "Ibrahem" },
                    { 6, "Nasr City", 190f, "2.jpg", "Fawzy" },
                    { 7, "Dokki", 100f, "3.jpg", "Mohamed" }
                });

            migrationBuilder.InsertData(
                table: "CourseResults",
                columns: new[] { "Id", "CourseId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 80f, 1 },
                    { 2, 3, 90f, 1 },
                    { 3, 5, 75f, 1 },
                    { 4, 2, 90f, 2 },
                    { 5, 1, 95f, 2 },
                    { 6, 4, 70f, 2 },
                    { 7, 5, 90f, 3 },
                    { 8, 3, 140f, 3 },
                    { 9, 1, 90f, 5 },
                    { 10, 3, 110f, 5 },
                    { 11, 5, 60f, 5 },
                    { 12, 5, 80f, 7 },
                    { 13, 4, 60f, 7 },
                    { 14, 1, 80f, 7 },
                    { 15, 4, 80f, 6 },
                    { 16, 3, 120f, 6 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CourseId", "DepartmentId", "ImagePath", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Moatam", 1, 2, "1.jpg", "Dr.Khaled", 5000f },
                    { 2, "El-zahraa", 5, 1, "3.jpg", "Dr.Mona", 15000f },
                    { 3, "Agouza", 1, 2, "2.jpg", "Dr.Sara", 8000f },
                    { 4, "October", 5, 3, "1.jpg", "Dr.Sally", 9000f },
                    { 5, "Alex", 2, 4, "3.jpg", "Dr.Ismail", 10000f },
                    { 6, "El-Rehab", 3, 4, "4.jpg", "Dr.Sami", 20000f },
                    { 7, "Aswan", 4, 1, "2.jpg", "Dr.Samir", 12000f },
                    { 8, "Nasr City", 5, 3, "4.jpg", "Dr.Mahmoud", 11000f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_CourseId",
                table: "CourseResults",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_TraineeId",
                table: "CourseResults",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseId",
                table: "Instructors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentId",
                table: "Instructors",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResults");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
