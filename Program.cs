using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookProduct.AutoFac;
using BookProduct.Repository;
using BookProduct.Repository.Data;
using BookProduct.Repository.IRepository;
using BookProduct.Repository.UnitOfWork;
using BookProduct.Service;
using BookProduct.Utils.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnention")));


builder.Services.AddCors(options =>
{
    // CorsPolicy 是自訂的 Policy 名稱
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin();
              
    });
});

builder.Services.AddMvc().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(OrganizationProfile));

//這段是使用AutoFac的部分
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutoFacModuleRegister());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
