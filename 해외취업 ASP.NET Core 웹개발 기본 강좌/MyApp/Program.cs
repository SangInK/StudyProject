using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region ==================== web application 종속성 주입 
//Transient: 요청 받을 때마다 생성
builder.Services.AddTransient<DbSeeder>();

//Scoped : 요청 당 한 번 생성
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//Singleton : 처음으로 요청 받을 때에 생성. 이후의 요청들은 최초에 생성된 인스턴스를 사용.

#endregion


builder.Services.AddDbContext<MyAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyAppConnection"));
});

var app = builder.Build();

// Transient로 종속성 주입된 DbSeeder의 SeedDatabase() 함수를 호출
app.Services.CreateScope().ServiceProvider.GetService<DbSeeder>().SeedDatabase().Wait();


app.UseHttpsRedirection();
app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.UseAuthorization();

app.Run();
