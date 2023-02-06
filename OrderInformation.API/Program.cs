using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderInformation.API.Services;
using OrderInformation.Business.Mapping;
using OrderInformation.Business.Services;
using OrderInformation.Core.Repositories;
using OrderInformation.Core.Services;
using OrderInformation.Core.UnitOfWorks;
using OrderInformation.Repository;
using OrderInformation.Repository.Repositories;
using OrderInformation.Repository.UnitOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IOrderInformationRepository, OrderInformationRepository>();
builder.Services.AddScoped<IOrderInformationService, OrderInformationService>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapProfile());
});
//IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mappingConfig.CreateMapper());

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});




builder.Services.AddHttpClient<OrderStatuService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["OrderStatuService"]);

});
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
