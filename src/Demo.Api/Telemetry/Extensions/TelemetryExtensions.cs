using System.Diagnostics.Metrics;

using Demo.Api.Telemetry.Metrics;

using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Demo.Api.Telemetry.Extensions;

public static class TelemetryExtensions
{
    public static IServiceCollection AddTelemetry(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceName = configuration["SERVICE_NAME"]!;

        var otlpEndpoint = configuration["OTLP_ENDPOINT_URL"]!;

        services.AddMetrics();

        var otel = services.AddOpenTelemetry();

        otel.ConfigureResource(resource => resource
            .AddService(serviceName: serviceName)
            .AddTelemetrySdk());

        otel.WithMetrics(metrics => metrics
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddRuntimeInstrumentation()
                .AddMeter(OrderMetrics.Name)
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

    public static IServiceCollection AddMetrics(this IServiceCollection services)
    {
        var meter = new Meter(OrderMetrics.Name, OrderMetrics.Version);

        services.AddSingleton(meter);
        services.AddSingleton<OrderMetrics>();

        return services;
    }
}
