using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Entitiy����� ���� ����
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
}).AddEntityFrameworkStores<MyAppContext>();


#region ==================== web application ���Ӽ� ���� 
//Transient: ��û ���� ������ ����
builder.Services.AddTransient<DbSeeder>();

//Scoped : ��û �� �� �� ����
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//Singleton : ó������ ��û ���� ���� ����. ������ ��û���� ���ʿ� ������ �ν��Ͻ��� ���.

#endregion


builder.Services.AddDbContext<MyAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyAppConnection"));
});

var app = builder.Build();

// Transient�� ���Ӽ� ���Ե� DbSeeder�� SeedDatabase() �Լ��� ȣ��
//app.Services.CreateScope().ServiceProvider.GetService<DbSeeder>().SeedDatabase().Wait();


app.UseHttpsRedirection();
app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
