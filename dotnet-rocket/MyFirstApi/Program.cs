using MyFirstApi;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
//aqui o ASP.NET esta escaneando o meu programa e procurando os controllers

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(option => option.LowercaseUrls = true);

//var test = builder.Configuration.GetSection("Prop1").Value;

var app = builder.Build();
//aqui ele esta fazendo a criação do servidor todo configurado

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// é aqui que ele mapea as rotas com base nos controllers, por isso eu não precisso usar o MapGet("/rota"), porque aqui ele usar os controllers do 
//meu programa que foram adicionados das minhas classes.

// lembrar do projeto minimal API, lá eu precisei fazer igual os frameworks JS, preciso app.MapGet('/',()=>{}), ou seja. Eu não preciso fazer isso aqui
//porque o ASP.NET leu toda as minhas classes com o builder.Services.AddControllers(); lá em cima, e aqui ele fez os mapeamentos em quais funcões 
//deveriam ser executadas em quais rotas.

//eu faço os mapeamentos antes de executar o servidor.

app.Run();
