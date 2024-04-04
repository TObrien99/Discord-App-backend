using Discord_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add a policy that allow us to use the PUT method. 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod(); // Allow any method, including PUT
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows origins (addresses) to send CRUD requests
builder.Services.AddCors();

// tells the builder to use our db context which we created as a framework for our database
builder.Services.AddDbContext<DiscordAppContext>(options =>
options.UseSqlite(builder.Configuration["ConnectionStrings:DiscordAppConnection"])
);

// when the client connects, we create an instance of the EF repository so that everyone has their own unique instance of the data 
builder.Services.AddScoped<IDiscordBotRequestsRepository, EFDiscordBotRequests>();
builder.Services.AddScoped<IDiscordUsersRepository, EFDiscordUsers>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); // Apply CORS policy

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
