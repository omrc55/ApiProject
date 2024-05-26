using BtkApiProject.Application.Exceptions.Common;

namespace BtkApiProject.Application.Exceptions.Products;

public class PriceOutOfRangeBadRequestException() : BadRequestException("The price value must be entered in a correct range.") { }