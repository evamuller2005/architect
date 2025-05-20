using Microsoft.AspNetCore.Mvc;
using ArchitectWeb.Models;

namespace ArchitectWeb.Controllers;

public class ProjectController : Controller
{
    public static List<Project> projects = new();

    public IActionResult Index()
    {
        Console.WriteLine(">>> Klic metode Index()");
        return View(projects);
    }

    public IActionResult Add() => View();

    [HttpPost]
    public IActionResult Add(Project project, IFormFile imageFile)
{
    if (string.IsNullOrWhiteSpace(project.Title))
    {
        ModelState.AddModelError("Title", "Naslov je obvezen.");
        return View(project);
    }

    // Shrani sliko
    if (imageFile != null && imageFile.Length > 0)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        Directory.CreateDirectory(uploadsFolder); // Ustvari mapo, če še ne obstaja

        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            imageFile.CopyTo(fileStream);
        }

        project.ImagePath = "/uploads/" + uniqueFileName;
    }

    project.ProjectID = new Random().Next(1000, 9999);
    projects.Add(project);

    return RedirectToAction("Index");
}

    [HttpPost]
    public IActionResult Search(string keyword)
    {
        var results = projects
            .Where(p => p.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || p.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return View("Index", results);
    }
    
    public IActionResult Details(int id) {
        var project = projects.FirstOrDefault(p => p.ProjectID == id);
        if (project == null) return NotFound();
        return View(project);
    }


}
