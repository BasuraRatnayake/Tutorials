using Microsoft.AspNetCore.SignalR;
using TestSignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/* Send Message From Server To Client */
app.MapPost("broadcast", async (string message, IHubContext<ComHub, IComHub> context) => {
    await context.Clients.All.RecieveMessage(message);
    return Results.NoContent();
});

app.MapHub<ComHub>("com-hub");

app.Run();
