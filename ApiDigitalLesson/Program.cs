using ApiDigitalLesson.DL;
using ApiDigitalLesson.Extensions;
using ApiDigitalLesson.Identity;

var builder = WebApplication.CreateBuilder(args);
var ConfigBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json");
var config = ConfigBuilder.Build();

// Add services to the container.
builder.Services.AddCustomSwagger();
builder.Services.AddSingleton(config);
builder.Services.AddIdentity(config);
builder.Services.AddModules(config);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//if (builder != null)
//{
//    var provider = builder.Services.BuildServiceProvider();
//    var userManager = provider.GetRequiredService<UserManager<User>>();
//    var roleManager = provider.GetRequiredService<RoleManager<Role>>();
//    await DefaultRoles.SeedAsync(roleManager);
//    await DefaultAdmin.SeedAsync(userManager);
//}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
