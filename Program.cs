using Invoices;

var builder = WebApplication.CreateBuilder(args);
// co znamena tento kod
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

startup.Configure(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();