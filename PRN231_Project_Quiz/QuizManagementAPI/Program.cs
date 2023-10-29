using BusinessObject.Models;
using DTO.MappingProfile;
using Microsoft.OData.ModelBuilder;
using Repository.IRepository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ODataConventionModelBuilder modelbuilder = new ODataConventionModelBuilder();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IQuestionRepository, QuestionRepository>();
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
builder.Services.AddSingleton<ISubjectRepository, SubjectRepository>();
builder.Services.AddSingleton<IQuizRepository, QuizRepository>();
builder.Services.AddSingleton<IQuizHistoryRepository, QuizHistoryRepository>();
builder.Services.AddSingleton<IRegisterRepository, RegisterRepository>();
builder.Services.AddSingleton<IExpertAssignRepository, ExpertAssignRepository>();
builder.Services.AddSingleton<IAnswerRepository, AnswerRepository>();
builder.Services.AddSingleton<ICourseCategoryRepository, CourseCategoryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
