var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:1453");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();