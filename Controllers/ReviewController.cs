using Microsoft.AspNetCore.Mvc;
using ArchitectWeb.Models;
using ArchitectWeb.Controllers; // ⬅️ dodaj to vrstico

namespace ArchitectWeb.Controllers;

public class ReviewController : Controller {
    private static List<Project> allProjects = ProjectController.projects;

    [HttpGet]
    public IActionResult Add(int projectId) {
        ViewBag.ProjectID = projectId;
        return View();
    }

    [HttpPost]
    public IActionResult Add(int projectId, Review review) {
        var project = allProjects.FirstOrDefault(p => p.ProjectID == projectId);
        if (project == null) return NotFound();

        project.Reviews.Add(review);
        return RedirectToAction("Details", "Project", new { id = projectId });
    }
}
