using ApiDigitalLesson.BL;
using ApiDigitalLesson.Common;
using ApiDigitalLesson.Extensions;
using ApiDigitalLesson.Identity;
using AspDigitalLesson.Model.Mapping;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json");
var config = configBuilder.Build();

builder.Host.UseSerilog((context, logConfig) => logConfig
    .ReadFrom.Configuration(context.Configuration)        
    .WriteTo.Console());

builder.Services.AddCors(options =>
{
    options.AddPolicy("Test", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddCustomSwagger();
builder.Services.AddSingleton(config);
builder.Services.AddIdentity(config);
builder.Services.AddModules(config);
builder.Services.AddCommonModules(config);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

//if (builder != null)
//{
//    var provider = builder.Services.BuildServiceProvider();
//    var userManager = provider.GetRequiredService<UserManager<User>>();
//    var roleManager = provider.GetRequiredService<RoleManager<Role>>();
//    await DefaultRoles.SeedAsync(roleManager);
//    await DefaultAdmin.SeedAsync(userManager);
//}

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("Test");

app.UseSerilogRequestLogging();
app.UseStaticFiles(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
