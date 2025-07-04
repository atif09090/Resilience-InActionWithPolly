# 🛡️ Resilience in Action with Polly (.NET 8 Web API)

This project demonstrates how to use [Polly](https://github.com/App-vNext/Polly) — a .NET resilience and transient-fault-handling library — to build fault-tolerant HTTP requests using various policies like Retry, Circuit Breaker, Timeout, Fallback, and Bulkhead.

## 🚀 What It Does

- Makes HTTP calls to a real external public API ([JSONPlaceholder](https://jsonplaceholder.typicode.com/posts/1)).
- Applies multiple resilience strategies using Polly.
- Returns resilient responses even under network failures or timeouts.

---

## 🧱 Features

| Policy            | Description                                                                 |
|-------------------|-----------------------------------------------------------------------------|
| 🔁 Retry          | Retries failed HTTP requests with exponential backoff                       |
| 🚫 Circuit Breaker| Stops calling a failing service temporarily                                 |
| ⏱️ Timeout        | Fails a request if it takes too long                                        |
| 🧯 Fallback        | Returns a default response when all else fails                             |
| 🧵 Bulkhead        | Limits number of concurrent requests to avoid service overload             |

---

## 📦 NuGet Packages

```plaintext
Resilience_InActionWithPolly/
├── Controllers/
│   └── ExternalApiController.cs
├── Services/
│   └── ExternalApiService.cs
├── Resilience/
│   └── PollyPolicies.cs
├── Program.cs
├── README.md



```bash
dotnet add package Microsoft.Extensions.Http.Polly
dotnet add package Polly
