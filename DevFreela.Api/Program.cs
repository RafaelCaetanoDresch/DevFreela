using DevFreela.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerGen();

builder.AddConfiguration();
builder.AddDatabaseConfiguration();
builder.AddRepositories();
builder.AddServices();
builder.AddMediator();
builder.AddJwtAuthentication();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
