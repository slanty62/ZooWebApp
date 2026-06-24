using Microsoft.EntityFrameworkCore;
using ZooWebApp.Data;
using ZooWebApp.Repositories;
using ZooWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Добавление сервисов в контейнер DI
builder.Services.AddControllersWithViews();

// 2. Настройка базы данных (SQLite для простоты, можно заменить на SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Регистрация репозиториев и сервисов
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// 4. Настройка логирования
builder.Services.AddLogging();

var app = builder.Build();

// 5. Настройка конвейера HTTP-запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 6. Маршрутизация
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 7. Инициализация базы данных (миграции и сидирование)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();