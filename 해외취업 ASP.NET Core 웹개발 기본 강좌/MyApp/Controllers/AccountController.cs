using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.ViewModels;

namespace MyApp.Models
{
    public class AccountController : Controller
    {
        #region ==================== 생성자 Region
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #endregion


        #region ==================== 전역변수 Region
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 3번째 매개변수 >> 브라우저가 닫힐 때 쿠키가 지속될 지의 여부. false일 경우 지속 안함
                // 4번째 매개변수 >> 유저가 로그인에 실패할 경우 계정잠금 여부. false일 경우 지속 안함.
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Student", "Home");
                }

                ModelState.AddModelError("", "로그인 실패");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, NickName = model.NickName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                ModelState.AddModelError("", "회원가입 실패");
            }

            return View(model);
        }

        public async Task<IActionResult> GetAdminRole()
        {
            //var adminAccount = await _userManager.FindByNameAsync("test@test.com");
            var adminAccount = _userManager.Users.ToList<ApplicationUser>()[0];
            var adminRole = new IdentityRole("Admin");

            await _roleManager.CreateAsync(adminRole);
            await _userManager.AddToRoleAsync(adminAccount, adminRole.Name);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteAdminRole()
        {
            var adminAccount = _userManager.Users.ToList<ApplicationUser>()[0];
            var adminRole = new IdentityRole("Admin");

            if ((await _userManager.GetRolesAsync(adminAccount)).Contains("Admin"))
            {
                await _roleManager.CreateAsync(adminRole);
                await _userManager.RemoveFromRoleAsync(adminAccount, adminRole.Name);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
