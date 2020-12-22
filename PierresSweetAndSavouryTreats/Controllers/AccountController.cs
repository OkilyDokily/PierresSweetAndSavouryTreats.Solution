using Microsoft.AspNetCore.Mvc;
using PierresSweetAndSavouryTreats.Models;
using Microsoft.AspNetCore.Identity;
using PierresSweetAndSavouryTreats.ViewModels;
using System.Threading.Tasks;
using System;

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
    public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
    {
      Microsoft.AspNetCore.Identity.IdentityResult result = await _userManager.CreateAsync(new ApplicationUser { UserName = registerViewModel.Email }, registerViewModel.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Register");

    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel login)
    {
      var signInResult = await _signInManager.PasswordSignInAsync(login.Email, login.Password, true, false);
      if (signInResult.Succeeded)
      {
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return RedirectToAction("Login");
      }
    }
    [HttpPost]
    public async Task<ActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}