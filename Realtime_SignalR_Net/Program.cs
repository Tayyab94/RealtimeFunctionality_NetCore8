using Microsoft.AspNetCore.SignalR;
using Realtime_SignalR_Net.Interfaces;
using Realtime_SignalR_Net.Models.SignalRClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();

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

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting(); // Add this BEFORE app.UseEndpoints
//app.MapHub<NotificationsHub>("notifications-hub");

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationsHub>("notifications-hub");
});


app.MapPost("notifications/all", 
    async(string content,IHubContext<NotificationsHub, INotificationsClient> context)
    =>
    {


    await context.Clients.All.ReceiveNotification(content);

    return Results.NoContent();

});

app.Run();
