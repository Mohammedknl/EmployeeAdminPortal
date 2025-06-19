using EmployeeAdminPortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adding services/Injecting services to container.

builder.Services.AddControllers();

//Injecting swagger services/Adding swagger services.building swagger services here
// Here builder is object of Services class and AddEndpoints is the method getting
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger

//Now we will inject DbContext class that can be used inside our controller for Database DefaultConnection
//or used in any other applications using builder object
// Here builder is object of Services class and AddDbContext is the method getting with type as ApplictionDBContext
//And options as paramter using sql server and fetching the connection string as DefaultConnection mentioned in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//**Above lines are to inject the ApplicationDbContext inside the program.cs file



//Below is default code to run project
var app = builder.Build();

// Below is for swagger services 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Below is the default code to run project
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
