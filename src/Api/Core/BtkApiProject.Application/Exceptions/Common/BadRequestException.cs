namespace BtkApiProject.Application.Exceptions.Common;

public abstract class BadRequestException : Exception
{
    protected BadRequestException() : base("There was a problem with the request.") { }
    protected BadRequestException(string message) : base(message) { }
}