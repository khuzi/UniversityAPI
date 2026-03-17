using Microsoft.EntityFrameworkCore;
using UniversityAPI.Data;
using UniversityAPI.Repositories.attendance_Repository;
using UniversityAPI.Repositories.course_Repository;
using UniversityAPI.Repositories.management_Repository;
using UniversityAPI.Repositories.mark_Repository;
using UniversityAPI.Services.attendance_service;
using UniversityAPI.Services.course_service;
using UniversityAPI.Services.mark_service;
using UniversityAPI.Services.staffservice;
using UniversityAPI.Services.studentservice;
using UniversityAPI.Services.teacherservice;
using UniversityAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// DB CONTEXT=>
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
//Repository=>>>>
builder.Services.AddScoped
    (typeof(IManagementRepository<>),typeof(ManagementRepository<>));
builder.Services.AddScoped<ICourseRepository,CourseRepository>();
builder.Services.AddScoped<IMarkRepository,MarkRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

//SERVICES=>
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
