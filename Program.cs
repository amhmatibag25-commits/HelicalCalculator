var builder = WebApplication.CreateBuilder(args);

// 1. Idagdag ang serbisyo para sa MVC (Controllers with Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 2. I-configure ang HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 3. I-set ang "Default Route" - dito sinasabi na ang unang bubukas ay ang Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
