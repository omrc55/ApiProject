namespace BtkApiProject.Application.Exceptions.Common;

public abstract class NotFoundException(string value, string id) : Exception($"{value} could not be found{id}") { }