using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_corsPolicy";

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dash-Vendedor-MVC", Version = "v1" });
});


builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name:corsPolicy,
                      policy  =>
                      {
                          policy.WithOrigins("https://localhost:7117",
                                              "http://localhost:5101"); 
                      });
});  

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0.0");
    });
app.Run();
