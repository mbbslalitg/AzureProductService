using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductService.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddAzureKeyVault(
    new Uri("https://productservice-kv.vault.azure.net/"),
    new DefaultAzureCredential()
);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["proddbsconstr"]));
//Console.WriteLine("keyvalut string-" + builder?.Configuration["proddbsconstr"]?.ToString());
var app = builder.Build();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();

 
