using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rent_A_Moment.Dto;
using Rent_A_Moment.Entity;
using Rent_A_Moment.Models;

namespace Rent_A_Moment.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(AppDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Register
        public ActionResult Register()
        {

            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterDto input)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = input.Email, Email = input.Email }; //create object
                var Result = await _userManager.CreateAsync(user, input.Password);
                if (Result.Succeeded == true) //if(Result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    Customer customer = new Customer()
                    {
                        Name = input.Name,
                        UserId = user.Id,//value primary key;
                        Email = input.Email,
                        Password = input.Password
                    };
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }

               
            }
            return View(input);
        }


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginDto input)
        {
            var Result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, false);

            if (Result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index");
                    }
                    else if (roles.Contains("Customer"));
                  {
                        return RedirectToAction("index");
                    }
                        
                }               
            }
            else
            {
                ModelState.AddModelError("error", "invalid Email or password");

            }
            return View();
        }

        // GET: Logout
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
