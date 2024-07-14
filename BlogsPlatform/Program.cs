using System.Text;
using BlogsPlatform.Utils._AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Repository;
using MyBlog.Service;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(CustomAutoMapperProfile));

builder.Services.AddSwaggerGen(c =>
{
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Description = "input 'Bearer token'",
    Name = "Authorization",
    BearerFormat = "JWT",
    Scheme = "Bearer"
  });
  c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference=new OpenApiReference
              {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
              }
            },
            new string[] {}
          }
        });
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VFKSDK")),
                ValidateIssuer = true,
                ValidIssuer = "http://localhost:6060",
                ValidateAudience = true,
                ValidAudience = "http://localhost:7146",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(60)
              };
            });


builder.Services.AddSqlSugar(new IocConfig()
{
  ConnectionString = builder.Configuration["SqlConn"],
  DbType = IocDbType.MySql,
  IsAutoCloseConnection = true
});


builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ITypeRepository, TypeRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<IArticleService, ArticleService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}


app.UseAuthentication();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
