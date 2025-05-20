namespace ArchitectWeb.Models;

public class Architect {
    public int UserID { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string Bio { get; set; } = "";
    public string Portfolio { get; set; } = "";
    public List<Project> Projects { get; set; } = new();
}
