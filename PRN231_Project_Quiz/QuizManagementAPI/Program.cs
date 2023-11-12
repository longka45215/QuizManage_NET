using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using DTO.MappingProfile;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Repository.IRepository;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ODataConventionModelBuilder modelbuilder = new ODataConventionModelBuilder();
modelbuilder.EntitySet<UserDTO>("User");
modelbuilder.EntitySet<AnswerDTO>("Answer");
modelbuilder.EntitySet<CourseCategoryDTO>("CourseCategory");
modelbuilder.EntitySet<CourseDTO>("Course");
modelbuilder.EntitySet<QuestionDTO>("Question");
modelbuilder.EntitySet<QuizDTO>("Quiz");
modelbuilder.EntitySet<SubjectDTO>("Subject");
modelbuilder.EntitySet<RoleDTO>("Role");
builder.Services.AddControllers().AddOData(option => option.Select()
        .Filter().Count().OrderBy().Expand().SetMaxTop(100)
        .AddRouteComponents("odata", modelbuilder.GetEdmModel()));
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
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<AnswerService>();
builder.Services.AddSingleton<CourseCategoryService>();
builder.Services.AddSingleton<CourseService>();
builder.Services.AddSingleton<ExpertAssignService>();
builder.Services.AddSingleton<QuestionService>();
builder.Services.AddSingleton<QuizHistoryService>();
builder.Services.AddSingleton<QuizService>();
builder.Services.AddSingleton<RegisterService>();
builder.Services.AddSingleton<SubjectService>();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
