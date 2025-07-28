using System.Diagnostics.Metrics;

namespace Demo.Api.Telemetry.Metrics;

public class OrderMetrics
{
    public const string Name = "demo.orders";
    public const string Version = "1.0";

    private readonly Counter<long> _ordersAccepted;

    public OrderMetrics(Meter meter)
    {
        _ordersAccepted = meter.CreateCounter<long>("orders.accepted", description: "Número de pedidos aceitos");
    }

    public void RecordOrderAccepted()
    {
        _ordersAccepted.Add(1);
    }
}