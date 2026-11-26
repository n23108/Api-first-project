using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using Microsoft.Extensions.Configuration;
using NLog.Web;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordsService, PasswordsService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddDbContext<ManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("home")),
    ServiceLifetime.Transient);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Logger.LogInformation("Starting WEB-API in {Environment} environment", app.Environment.EnvironmentName);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.Run();
