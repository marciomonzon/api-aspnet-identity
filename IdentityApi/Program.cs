using IdentityApi.Data;
using IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<SignInManager<User>>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<User>();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger().RequireAuthorization();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
