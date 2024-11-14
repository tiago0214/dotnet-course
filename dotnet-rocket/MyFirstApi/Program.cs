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
//aqui ele esta fazendo a cria��o do servidor todo configurado

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// � aqui que ele mapea as rotas com base nos controllers, por isso eu n�o precisso usar o MapGet("/rota"), porque aqui ele usar os controllers do 
//meu programa que foram adicionados das minhas classes.

// lembrar do projeto minimal API, l� eu precisei fazer igual os frameworks JS, preciso app.MapGet('/',()=>{}), ou seja. Eu n�o preciso fazer isso aqui
//porque o ASP.NET leu toda as minhas classes com o builder.Services.AddControllers(); l� em cima, e aqui ele fez os mapeamentos em quais func�es 
//deveriam ser executadas em quais rotas.

//eu fa�o os mapeamentos antes de executar o servidor.

app.Run();
