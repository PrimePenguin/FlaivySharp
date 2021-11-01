# FlaivySharp: A .NET library for Flaivy.

Flaivy is a .NET library that enables you to authenticate and make API calls to Flaivy. It's great for
building custom Flaivy Apps using C# and .NET. You can quickly and easily get up and running with Flaivy
using this library.

# Installation

Flaivy is [available on NuGet](https://www.nuget.org/packages/Flaivy/). Use the package manager
console in Visual Studio to install it:

```
Install-Package Flaivy
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package Quickbutik
```

# Using Flaivy

**Note**: All instances of `accessToken` in the examples below **do not refer to your Flaivy accessToken**.
An access token is the token returned after authenticating and authorizing a Quickbutik app installation with a
real Flaivy store.

```cs
var service = new ProductService(accessToken);
```

# APIS Implemented

- Order
- Product
