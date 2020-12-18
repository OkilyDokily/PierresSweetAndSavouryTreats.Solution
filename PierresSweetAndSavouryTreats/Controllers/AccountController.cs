using Microsoft.AspNetCore.Mvc;
using PierresSweetAndSavouryTreats.Models;
using Microsoft.AspNetCore.Identity;
using PierresSweetAndSavouryTreats.ViewModels;

namespace PierresSweetAndSavouryTreats.Controllers
{
  public class AccountController : Controller
  {
    public SignInManager<ApplicationUser> _signInManager;
    public UserManager<ApplicationUser> _userManager;
    public PierresSweetAndSavouryTreatsContext _db;
    public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, PierresSweetAndSavouryTreatsContext db)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Register()
    {
      return View();
    }

    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Register(RegisterViewModel registerViewModel)
    {
      _userManager.CreateAsync(new ApplicationUser { Email = registerViewModel.Email, PasswordHash = registerViewModel.Password });
      return RedirectToAction("Index");
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel login)
    {
      _signInManager.PasswordSignInAsync(login.Email, login.Password, true, false);
      return RedirectToAction("Index");
    }
  }
}