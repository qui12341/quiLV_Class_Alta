using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiLV_ALTA_Class.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number_Of_Students = table.Column<int>(type: "int", nullable: false),
                    School_Fee = table.Column<float>(type: "real", nullable: false),
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.Class_Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "holiday_Schedules",
                columns: table => new
                {
                    Holiday_Schedule_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Holiday_Schedule_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time_End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holiday_Schedules", x => x.Holiday_Schedule_Id);
                });

            migrationBuilder.CreateTable(
                name: "nest_Departments",
                columns: table => new
                {
                    Nest_Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nest_Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nest_Departments", x => x.Nest_Department_Id);
                });

            migrationBuilder.CreateTable(
                name: "point_types",
                columns: table => new
                {
                    Point_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point_Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coefficient = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point_types", x => x.Point_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "revenue",
                columns: table => new
                {
                    Revenue_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Revenue_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenue", x => x.Revenue_Id);
                    table.ForeignKey(
                        name: "FK_revenue_classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "classes",
                        principalColumn: "Class_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Subject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nest_Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Subject_ID);
                    table.ForeignKey(
                        name: "FK_subjects_nest_Departments_Nest_Department_Id",
                        column: x => x.Nest_Department_Id,
                        principalTable: "nest_Departments",
                        principalColumn: "Nest_Department_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nest_Department_Id = table.Column<int>(type: "int", nullable: false),
                    Concurrently = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.Teacher_Id);
                    table.ForeignKey(
                        name: "FK_teacher_nest_Departments_Nest_Department_Id",
                        column: x => x.Nest_Department_Id,
                        principalTable: "nest_Departments",
                        principalColumn: "Nest_Department_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_user_role_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "role",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    Point_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    Point_Type_ID = table.Column<int>(type: "int", nullable: false),
                    Score_Column_Number = table.Column<int>(type: "int", nullable: false),
                    Required_Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.Point_ID);
                    table.ForeignKey(
                        name: "FK_points_courses_Course_ID",
                        column: x => x.Course_ID,
                        principalTable: "courses",
                        principalColumn: "Course_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_points_point_types_Point_Type_ID",
                        column: x => x.Point_Type_ID,
                        principalTable: "point_types",
                        principalColumn: "Point_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_points_subjects_Subject_ID",
                        column: x => x.Subject_ID,
                        principalTable: "subjects",
                        principalColumn: "Subject_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject_Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subject_Classes_classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "classes",
                        principalColumn: "Class_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_Classes_subjects_Subject_ID",
                        column: x => x.Subject_ID,
                        principalTable: "subjects",
                        principalColumn: "Subject_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_Id = table.Column<int>(type: "int", nullable: false),
                    Subject_ID = table.Column<int>(type: "int", nullable: false),
                    Study_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassRoom = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calendars_classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "classes",
                        principalColumn: "Class_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calendars_subjects_Subject_ID",
                        column: x => x.Subject_ID,
                        principalTable: "subjects",
                        principalColumn: "Subject_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calendars_teacher_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "teacher",
                        principalColumn: "Teacher_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_CLasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_Id = table.Column<int>(type: "int", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_CLasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacher_CLasses_classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "classes",
                        principalColumn: "Class_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_CLasses_teacher_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "teacher",
                        principalColumn: "Teacher_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wages",
                columns: table => new
                {
                    Wage_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_Id = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_Salary = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wages", x => x.Wage_ID);
                    table.ForeignKey(
                        name: "FK_wages_teacher_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "teacher",
                        principalColumn: "Teacher_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Student_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false),
                    Student_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK_student_user_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "point_Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_Id = table.Column<int>(type: "int", nullable: false),
                    Point_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_point_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_point_Classes_classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "classes",
                        principalColumn: "Class_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_point_Classes_points_Point_ID",
                        column: x => x.Point_ID,
                        principalTable: "points",
                        principalColumn: "Point_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_student_Classes_classes_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "classes",
                        principalColumn: "Class_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_Classes_student_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "student",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_calendars_Class_Id",
                table: "calendars",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_calendars_Subject_ID",
                table: "calendars",
                column: "Subject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_calendars_Teacher_Id",
                table: "calendars",
                column: "Teacher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_point_Classes_Class_Id",
                table: "point_Classes",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_point_Classes_Point_ID",
                table: "point_Classes",
                column: "Point_ID");

            migrationBuilder.CreateIndex(
                name: "IX_points_Course_ID",
                table: "points",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_points_Point_Type_ID",
                table: "points",
                column: "Point_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_points_Subject_ID",
                table: "points",
                column: "Subject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_revenue_Class_Id",
                table: "revenue",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_student_User_ID",
                table: "student",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_student_Classes_Class_Id",
                table: "student_Classes",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_student_Classes_Student_Id",
                table: "student_Classes",
                column: "Student_Id");

            migrationBuilder.CreateIndex(
                name: "IX_subject_Classes_Class_Id",
                table: "subject_Classes",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_subject_Classes_Subject_ID",
                table: "subject_Classes",
                column: "Subject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_Nest_Department_Id",
                table: "subjects",
                column: "Nest_Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_Nest_Department_Id",
                table: "teacher",
                column: "Nest_Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_CLasses_Class_Id",
                table: "teacher_CLasses",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_CLasses_Teacher_Id",
                table: "teacher_CLasses",
                column: "Teacher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_Role_ID",
                table: "user",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_wages_Teacher_Id",
                table: "wages",
                column: "Teacher_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calendars");

            migrationBuilder.DropTable(
                name: "holiday_Schedules");

            migrationBuilder.DropTable(
                name: "point_Classes");

            migrationBuilder.DropTable(
                name: "revenue");

            migrationBuilder.DropTable(
                name: "student_Classes");

            migrationBuilder.DropTable(
                name: "subject_Classes");

            migrationBuilder.DropTable(
                name: "teacher_CLasses");

            migrationBuilder.DropTable(
                name: "wages");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "point_types");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "nest_Departments");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
