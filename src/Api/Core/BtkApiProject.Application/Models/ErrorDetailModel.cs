using System.Text.Json;

namespace BtkApiProject.Application.Models;

public sealed record ErrorDetailModel
{
    public int StatusCode { get; init; }
    public string? Message { get; init; }

    public override string ToString() => JsonSerializer.Serialize(this);
}