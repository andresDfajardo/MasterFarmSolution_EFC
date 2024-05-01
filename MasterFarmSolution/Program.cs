using MasterFarmSolution;
using MasterFarmSolution.Repositories;
using MasterFarmSolution.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Repositories
builder.Services.AddScoped<IAgriculturalOperationRepository, AgriculturalOperationRepository>();
builder.Services.AddScoped<IAgriculturalOperationsTypeRepository, AgriculturalOperationsTypeRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IFarmerRepository, FarmerRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IHarvestRecordRepository, HarvestRecordRepository>();
builder.Services.AddScoped<IOperationXGameRepository, OperationXGameRepository>();
builder.Services.AddScoped<IPlotRepository, PlotRepository>();
builder.Services.AddScoped<IPlotTypeRepository, PlotTypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion
#region Services
builder.Services.AddScoped<IAgriculturalOperationService, AgriculturalOperationService>();
builder.Services.AddScoped<IAgriculturalOperationsTypeService, AgriculturalOperationsTypeService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<ICropService, CropService>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IFarmerService, FarmerService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IHarvestRecordService, HarvestRecordService>();
builder.Services.AddScoped<IOperationXGameService, OperationXGameService>();
builder.Services.AddScoped<IPlotService, PlotService>();
builder.Services.AddScoped<IPlotTypeService, PlotTypeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
