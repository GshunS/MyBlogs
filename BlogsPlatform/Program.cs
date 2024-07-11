using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

# region SqlSugarIOC
SugarIocServices.AddSqlSugar(new IocConfig()
 {
    //ConfigId="db01" 
   ConnectionString = builder.Configuration["SqlConn"],
   DbType = IocDbType.MySql,
   IsAutoCloseConnection = true
 });
# endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
