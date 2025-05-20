using Microsoft.AspNetCore.Mvc;
using ArchitectWeb.Models;

namespace ArchitectWeb.Controllers;

public class AuthController : Controller {
    public static List<User> users = new();

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(User user) {
        if (users.Any(u => u.Username == user.Username)) {
            ModelState.AddModelError("Username", "Uporabniško ime je že zasedeno.");
            return View(user);
        }

        user.Id = new Random().Next(1000, 9999);
        users.Add(user);
        TempData["User"] = user.Username;
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password) {
        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null) {
            ViewBag.Error = "Napačno uporabniško ime ali geslo.";
            return View();
        }

        TempData["User"] = user.Username;
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout() {
        TempData.Remove("User");
        return RedirectToAction("Index", "Home");
    }
}
