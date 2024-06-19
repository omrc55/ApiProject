﻿namespace BtkApiProject.Application.Helpers.Links;

public record Link
{
    public string? Href { get; init; }
    public string? Rel { get; init; }
    public string? Method { get; init; }

    public Link() { }

    public Link(string? href, string? rel, string? method)
    {
        Href = href;
        Rel = rel;
        Method = method;
    }
}