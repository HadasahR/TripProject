using AutoMapper;
using BLL;
using BLL.FunctionsBLL;
using BLL.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddInjectionBLL();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
//builder.Services.AddScoped<DAL.Interfaces.ITypes,DAL.Models.Type>();
//builder.Services.AddScoped<ITypeBLL,TypeFuncBLL>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
