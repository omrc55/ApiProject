using System.Text.Json;

namespace BtkApiProject.Application.Models;

public sealed record LogDetailModel
{
    public object? ModelName { get; init; }
    public object? Controller { get; init; }
    public object? Action { get; init; }
    public object? ID { get; set; }
    public object? CreatedAt { get; init; } = DateTime.Now;

    public override string ToString() => JsonSerializer.Serialize(this);
}