# OpenTelemetry Demo (.NET)

Sample hands-on project for .NET developers exploring [OpenTelemetry](https://opentelemetry.io/), presented during my lecture at **WTADS/WINFO**.

This project demonstrates distributed tracing, metrics, and logs collection using .NET + OpenTelemetry, integrated with tools like **Grafana**, **Prometheus**, and **Loki**.

---

## Stack

- ASP.NET Core Web API (.NET 8)
- OpenTelemetry (Tracing + Metrics + Logging)
- Grafana (Observability UI)
- Prometheus (Metrics backend)
- Loki (Logs backend)
- Tempo (Tracing backend)
- Docker & Docker Compose

---

## How to Run Locally

### Prerequisites

- Docker + Docker Compose
- `make` installed

### Steps

```bash
make up
```

## 🧹How to Stop and Clean Up

To stop and destroy all services, including volumes and orphan containers:

```bash
make down
```