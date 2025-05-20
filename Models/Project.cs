namespace ArchitectWeb.Models;

public class Project {
    public int ProjectID { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? ImagePath { get; set; }
    public int ArchitectID { get; set; }
    public List<Review> Reviews { get; set; } = new();
    public DateTime DatePosted { get; set; } = DateTime.Now;
}
