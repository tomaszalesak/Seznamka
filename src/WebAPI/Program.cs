using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);
var host = builder.Host;
var services = builder.Services;

host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessLayerConfig());
});

services.AddDbContext<SeznamkaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("SQLServer").Value));
services.AddControllers();
services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
});
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutofac();

services.AddAuthorization();
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

services.AddSignalR();

await using var app = builder.Build();

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
app.MapHub<ChatHub>("/chatHub");

await app.RunAsync();