namespace ForWork.Models;

public record LoginViewModel
{
    public Exception? Error { get; set; }
    public bool IsSuccess { get; set; }
    public string? Response { get; set; }
}