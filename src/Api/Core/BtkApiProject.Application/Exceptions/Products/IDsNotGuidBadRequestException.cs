using BtkApiProject.Application.Exceptions.Common;

namespace BtkApiProject.Application.Exceptions.Products;

public class IDsNotGuidBadRequestException(bool IDs) : BadRequestException(IDs ? "The entered values is not Guid." : "The entered value is not Guid.") { }