using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Server.Data;
using Server.Helpers;
using Server.Middleware;
using Server.Models;
using Server.Repostoriy;
using Server.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().WithMethods("POST", "GET", "PUT", "DELETE").WithHeaders(HeaderNames.ContentType);
    });
});
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// builder.Services.AddLogging(opt =>
// {
//     opt.AddConsole();
//     opt.AddDebug();
// });
// builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();



///Add Authenticate Swagger Button
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your Vaild Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{

    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {


        ////For Development onlyyyyyyyy===>>>>>> RequireExpirationTime=false
        RequireExpirationTime = false,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = false,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>(),
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Get<string>(),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
    };
});

// builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPostService, PostRepository>();
builder.Services.AddScoped<IUserService, UserRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentRepository>();
builder.Services.AddScoped(typeof(IGlobalService<Employee>), typeof(EmployeeRepository));
builder.Services.AddScoped<IActivityService, ActivityRepository>();
builder.Services.AddScoped<IReactsService, ReactsRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<TokenValidationParameters>();
builder.Services.AddScoped<JwtService>();

//Memoery Caching
builder.Services.AddMemoryCache();

//Response Caching
builder.Services.AddResponseCaching();

builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "";

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseRequestCulture();
// app.UseErrorHandleMiddleware();
// app.UseLocalizationMiddleware();
// app.UseMiddleware<RequestTimeMiddlware>();

app.UseRouting();
app.UseRateLimiter();
app.UseCors(MyAllowSpecificOrigins);

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
