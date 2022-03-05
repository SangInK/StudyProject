using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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
