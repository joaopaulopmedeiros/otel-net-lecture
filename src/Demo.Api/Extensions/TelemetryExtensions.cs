using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Demo.Api.Extensions;

public static class TelemetryExtensions
{
    public static IServiceCollection AddTelemetry(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationName = "demo-api";

        var otlpEndpoint = configuration["OTLP_ENDPOINT_URL"]!;

        if (string.IsNullOrEmpty(otlpEndpoint)) return services;

        var otel = services.AddOpenTelemetry();

        otel.ConfigureResource(resource => resource
            .AddService(serviceName: applicationName)
            .AddTelemetrySdk());

        otel.WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddRuntimeInstrumentation()
                .AddOtlpExporter(opt => opt.Endpoint = new Uri(otlpEndpoint))
                .AddConsoleExporter());

        otel.WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddOtlpExporter(opt => opt.Endpoint = new Uri(otlpEndpoint))
                .AddConsoleExporter());

        otel.WithLogging(logging => logging
                .AddOtlpExporter(opt => opt.Endpoint = new Uri(otlpEndpoint))
                .AddConsoleExporter());

        return services;
    }
}
