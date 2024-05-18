using BtkApiProject.Common.DTOs.Common;
using BtkApiProject.Common.Enums;
using BtkApiProject.Common.Tools;
using System.ComponentModel.DataAnnotations;

namespace BtkApiProject.Common.DTOs.Products;

public record ProductRequestDTO : BaseRequestDTO
{
    [Required(ErrorMessage = DataMessages.FieldRequired)]
    [StringLength((int)DataLengthEnum.NameMax, ErrorMessage = DataMessages.NameLength, MinimumLength = (int)DataLengthEnum.NameMin)]
    public string? Name { get; init; }

    [StringLength((int)DataLengthEnum.DescriptionMax, ErrorMessage = DataMessages.DescriptionLength)]
    public string? Description { get; init; }
    public double? Price { get; init; }

    [Required(ErrorMessage = DataMessages.FieldRequired)]
    public Guid? CategoryID { get; init; }

    public virtual required ProductDetailRequestDTO ProductDetail { get; init; }
}
