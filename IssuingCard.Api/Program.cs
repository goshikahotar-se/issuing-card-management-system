using IssuingCard.Api.Cards;
using IssuingCard.Application.Cards;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICardRepository, InMemoryCardRepository>();
builder.Services.AddScoped<CreateCardService>();
builder.Services.AddScoped<GetCardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/cards",
    async (CreateCardRequest request, CreateCardService service, CancellationToken cancellationToken) =>
    {
        var command = new CreateCardCommand
        {
            InitialLimit = request.InitialLimit,
            Currency = request.Currency
        };

        var result = await service.Handle(command, cancellationToken);

        return Results.Created($"/cards/{result.CardId}", result);
    });

app.MapGet("/cards/{cardId}",
    async (string cardId, GetCardService service, CancellationToken cancellationToken) =>
    {
        var result = await service.Handle(cardId, cancellationToken);
        
        if (result is null)
            return Results.NotFound();
        return Results.Ok(result);
    });
    
app.Run();

record CreateCardRequest(decimal InitialLimit, string Currency);