using Microsoft.AspNetCore.Mvc;
using ArchitectWeb.Models;

namespace ArchitectWeb.Controllers;

public class ArchitectController : Controller {
    private static List<Architect> architects = new();

    public IActionResult Index() => View(architects);

    public IActionResult Add() => View();

    [HttpPost]
    public IActionResult Add(Architect architect) {
        architect.UserID = new Random().Next(1000, 9999);
        architects.Add(architect);
        return RedirectToAction("Index");
    }

    public IActionResult Profile(int id) {
        var architect = architects.FirstOrDefault(a => a.UserID == id);
        if (architect == null) return NotFound();
        return View(architect);
    }
}
