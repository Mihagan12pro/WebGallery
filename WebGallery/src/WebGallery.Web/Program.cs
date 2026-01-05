using Microsoft.AspNetCore.CookiePolicy;
using WebGallery.Web;
using WebGallery.Web.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Services.AddProgramDependencies();

var app = builder.Build();

app.UseExceptionMiddleware();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    
    HttpOnly = HttpOnlyPolicy.Always,

    Secure = CookieSecurePolicy.Always
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "WebGallery");
    });
}

app.MapControllers();

app.UseAuthorization();
app.UseAuthentication();

app.Run();