using Oekaki.Core.Infrastructure.Resources;
using Oekaki.Data;
using Oekaki.Data.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddNpgsqlDbContext<ApplicationDbContext>("oekakidb");

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRoutes();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // using (var scope = app.Services.CreateScope())
    // {
    //     var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    //     context.Database.EnsureCreated();

    //     if (!context.Tests.Any())
    //     {
    //         context.Tests.Add(
    //             new Test { Title = "Test no. 1", Description = "Lorem Ipsum Dolor Sit Amet!!" }
    //         );
    //         context.SaveChanges();
    //     }
    // }
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// app.MapIdentityApi<User>();

app.Run();
