using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Helpers;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IQuizService, SqliteQuizService>();
builder.Services.AddDbContext<QuizzMeContext>(x=>x.UseSqlite("DataSource=quizzMe.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAllPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllPolicy");
app.UseMiddleware<HttpMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
