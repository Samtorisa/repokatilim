using ToDO.InterFace;
using ToDO.Manager;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors((g)=>g.AllowAnyOrigin());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Services.AddScoped<ManagerToDo>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
