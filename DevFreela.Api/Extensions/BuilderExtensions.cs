using DevFreela.Application.Validators;
using DevFreela.core;
using DevFreela.Core.Repository;
using DevFreela.Infra.Persistence;
using DevFreela.Infra.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using FluentValidation.AspNetCore;
using DevFreela.Api.Filters;

namespace DevFreela.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("Default") ?? string.Empty;
    }

    public static void AddDatabaseConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DevFreelaDbContext>(
            o => o.UseNpgsql(Configuration.Database.ConnectionString));
    }

    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
    }

    public static void AddMediator(this WebApplicationBuilder builder)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            builder.Services.AddMediatR(
            cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }

    public static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(o => o.Filters.Add(typeof(ValidationFilter)))
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

    }

    public static void AddSwaggerGen(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorizationg header usando o esquema Bearer."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }

    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = builder.Configuration["Jwt:Issuer"],
                      ValidAudience = builder.Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                  };
              });
    }
}
