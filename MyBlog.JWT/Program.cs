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
builder.Services.AddSwaggerGen();

builder.Services.AddSqlSugar(new IocConfig()
 {
   ConnectionString = builder.Configuration["SqlConn"],
   DbType = IocDbType.MySql,
   IsAutoCloseConnection = true
 });

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
