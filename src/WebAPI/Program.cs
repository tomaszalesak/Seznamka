using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);
var host = builder.Host;
var services = builder.Services;
const string allowAllOrigins = "allowAllOrigins";
const string hubUri = "/chatHub";

host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessLayerConfig());
});

services.AddCors(options =>
{
    options.AddPolicy(allowAllOrigins,
        corsPolicyBuilder => { corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
});

services.AddDbContext<SeznamkaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("SQLServer").Value));
services.AddControllers();
services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
});
services.AddHttpContextAccessor();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutofac();

services.AddAuthorization();
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ClockSkew = TimeSpan.FromSeconds(30)
    };
    opt.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments(hubUri))
                context.Token = accessToken;

            return Task.CompletedTask;
        }
    };
});
services.AddSignalR();
services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

await using var app = builder.Build();

app.UseCors(allowAllOrigins);
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "APIv1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>(hubUri, options => { options.CloseOnAuthenticationExpiration = true; });

await app.RunAsync();