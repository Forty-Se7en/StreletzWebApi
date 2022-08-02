using StreletzAPI;
using StreletzProxyServer;
using StreletzProxyServer.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
    c.EnableAnnotations(); });

builder.Services.AddSingleton<IClient, StreletzClient.StreletzClient>();
builder.Services.AddSingleton<IStreletzClientManagerService, StreletzClientManagerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();