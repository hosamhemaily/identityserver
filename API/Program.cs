using API.Services;
using DataAccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServerSettings"));

builder.Services.AddScoped<ITokenService,TokenService>();

//builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", delegate (JwtBearerOptions a)
//{
//    a.Authority = "https://localhost:5443";

//    a.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        ValidateActor = false,
//        ValidateAudience = false,
//        ValidateLifetime = false,
//        ValidateTokenReplay = false,
//        ValidateIssuer = false

//    };
//});

builder.Services.AddAuthorization(options  => {
    options.AddPolicy("canupdatedata",policy=>policy.RequireClaim("roleType", "canupdatedata"));
});

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.Authority = "https://localhost:5443";
        options.ApiName = "Api1";
        options.RoleClaimType = "role";
    });

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
