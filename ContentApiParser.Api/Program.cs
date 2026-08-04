using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IContentParser, CsvContentParser>();
builder.Services.AddSingleton<IContentParser, InternalJsonContentParser>();
builder.Services.AddSingleton<ParserService>();

var app = builder.Build();


app.MapPost("/api/v1/parse-content", (ParseContentRequest request, ParserService parserService) =>
{
    byte[] decodedBytes;
    try
    {
        decodedBytes = Convert.FromBase64String(request.Content);
    }
    catch (FormatException)
    {
        return Results.BadRequest(new { error = "Content is not valid Base64." });
    }

    var decodedContent = Encoding.UTF8.GetString(decodedBytes);

    try
    {
        var response = parserService.Parse(request.Type, decodedContent);
        return Results.Ok(response);
    }
    catch (ContentParsingException ex)
    {
        return Results.BadRequest(new { error = "Content parsing failed: " + ex.Message });
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

