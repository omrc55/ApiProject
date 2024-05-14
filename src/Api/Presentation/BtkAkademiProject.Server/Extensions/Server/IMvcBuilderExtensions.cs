using BtkAkademiProject.Server.Formatters;

namespace BtkAkademiProject.Server.Extensions.Server;

public static class IMvcBuilderExtensions
{
    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
        builder.AddMvcOptions(config => config.OutputFormatters.Add(new CSVOutputFormatter()));
}