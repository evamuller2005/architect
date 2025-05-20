namespace ArchitectWeb.Models;

public class Review {
    public string Author { get; set; } = "";
    public string Comment { get; set; } = "";
    public int Rating { get; set; } // 1–5
    public DateTime Timestamp { get; set; } = DateTime.Now;
}
