using MyApp.Models;

namespace MyApp.Data
{
    public class DbSeeder
    {
        #region ==================== 생성자 Region
        public DbSeeder(MyAppContext context)
        {
            _context = context;
        }

        #endregion


        #region ==================== 전역변수 Region
        private readonly MyAppContext _context;

        #endregion


        #region ==================== 함수 Region
        public async Task SeedDatabase()
        {
            if (!_context.Teachers.Any())
            {
                List<Teacher> teachers = new List<Teacher>()
                {
                    new Teacher() { Name = "세종대왕", Class = "한글" },
                    new Teacher() { Name = "이순신", Class = "해상전략" },
                    new Teacher() { Name = "제갈량", Class = "지략" },
                    new Teacher() { Name = "을지문덕", Class = "지상전력" }
                };

                await _context.AddAsync(new Teacher() { Name = "김상인", Class = "잉여학" });
                await _context.AddRangeAsync(teachers);

                await _context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
