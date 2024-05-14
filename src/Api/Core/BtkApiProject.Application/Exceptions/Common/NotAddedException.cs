namespace BtkApiProject.Application.Exceptions.Common;

public abstract class NotAddedException(string value, string id) : Exception($"{value} could not be added{id}") { }