using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Services.CalendarService;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.CourseService;
using quiLV_ALTA_Class.Services.Holiday_ScheduleService;
using quiLV_ALTA_Class.Services.JwtService;
using quiLV_ALTA_Class.Services.Nest_DepartmentService;
using quiLV_ALTA_Class.Services.Point_CLassService;
using quiLV_ALTA_Class.Services.Point_TypeService;
using quiLV_ALTA_Class.Services.PointService;
using quiLV_ALTA_Class.Services.RevenueService;
using quiLV_ALTA_Class.Services.RoleService;
using quiLV_ALTA_Class.Services.Student_ClassService;
using quiLV_ALTA_Class.Services.StudentService;
using quiLV_ALTA_Class.Services.Subject_ClassService;
using quiLV_ALTA_Class.Services.SubjectService;
using quiLV_ALTA_Class.Services.TeacherClassService;
using quiLV_ALTA_Class.Services.TeacherService;
using quiLV_ALTA_Class.Services.UserService;
using quiLV_ALTA_Class.Services.WageService;
using System.Text;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alta_Flight", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. " +
                      "Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        RoleClaimType = "Role"
                    };
                });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", "1"));  
    options.AddPolicy("TeacherOnly", policy => policy.RequireClaim("Role", "2"));
    options.AddPolicy("StudentOnly", policy => policy.RequireClaim("Role", "3"));
});

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentClassService, StudentClassService>();
builder.Services.AddScoped<IPointClassService, PointClassService>();
builder.Services.AddScoped<IPointService, PointService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<INestDepartmentService, NestDepartmentService>();
builder.Services.AddScoped<IPointTypeService, PointTypeService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IRevenueService, RevenueService>();
builder.Services.AddScoped<ITeacherClassService, TeacherClassService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IHoliday_ScheduleService, Holiday_ScheduleService>();
builder.Services.AddScoped<ISubjectClassService, SubjectClassService>();
builder.Services.AddScoped<IWageService, WageService>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMemoryCache();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
