using Aplicacao;
using Infra;

var builder = WebApplication.CreateBuilder(args);

ModuloDeInjecaoDaAplicacao.RegistrarServicos(builder.Services);
ModuloDeInjecaoDaInfra.RegistrarServicos(builder.Services);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
