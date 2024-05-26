using BtkApiProject.Application.Exceptions.Common;

namespace BtkApiProject.Application.Exceptions.Products;

public class QuantityOutOfRangeBadRequestException() : BadRequestException("The quantity value must be entered in a correct range.") { }