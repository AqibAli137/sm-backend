using sm_backend.Models;
using sm_backend.Repository;
using Microsoft.EntityFrameworkCore;
using sm_backend.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SmContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(sp => sp.GetService<IHttpContextAccessor>().HttpContext.Session);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Client", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .AllowCredentials();
    });
});


// Repository Dependencies
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IGatePassRepository, GatePassRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
