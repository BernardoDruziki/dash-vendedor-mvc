var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_corsPolicy";

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
