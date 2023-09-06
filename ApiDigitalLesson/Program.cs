using ApiDigitalLesson.BL;
using ApiDigitalLesson.Common;
using ApiDigitalLesson.Extensions;
using ApiDigitalLesson.Identity;
using ApiDigitalLesson.Model.Mapping;
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

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = config["Redis:Host"];
    options.InstanceName = config["Redis:InstanceName"];
});

builder.Services.AddCustomSwagger();
builder.Services.AddSingleton(config);
builder.Services.AddIdentity(config);
builder.Services.AddModules();
builder.Services.AddCommonModules(config);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// if (builder != null)
// {
//     var provider = builder.Services.BuildServiceProvider();
//     var userManager = provider.GetRequiredService<UserManager<UserIdentity>>();
//     var roleManager = provider.GetRequiredService<RoleManager<RoleIdentity>>();
//     await DefaultRoles.SeedAsync(roleManager);
//     await DefaultUser.CreateDefaultUser(userManager);
// }

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
