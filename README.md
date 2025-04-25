# 🧑‍💻 Class Type Performance Benchmark - .NET

This project compares the performance of different class types in C# using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet). It measures the differences in object creation and method invocation overhead.

## 🎯 Purpose

The purpose of this benchmark is to measure the performance differences between various C# class types, helping developers understand the overhead involved in choosing different class designs for their applications.

### Tested Class Types:

| **Class Type**       | **Description**                                               |
|----------------------|---------------------------------------------------------------|
| **Regular Class**     | Standard class, creates an object and calls a method.         |
| **Static Class**      | Static class, no object creation, method called directly.     |
| **Abstract Class**    | Abstract class, method called via a derived class.            |
| **Sealed Class**      | Sealed class, cannot be inherited, method called via an object.|
| **Record Class**      | Immutable reference type with parameters.                     |
| **Generic Class**     | Generic class, e.g., `GenericClass<int>`.                      |
| **Singleton Class**   | Singleton pattern, object created lazily.                     |

## 🔧 Technologies Used

- **.NET 8+** - Modern .NET platform
- **BenchmarkDotNet** - Performance measurement tool
- **C#** - Programming language
