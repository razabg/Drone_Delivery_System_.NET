# 🚁 Drone Delivery Management System

A comprehensive enterprise-level drone delivery management system built with C# and .NET 5, featuring a modern WPF interface and robust three-tier architecture. This system enables efficient management of drone fleets, parcels, customers, and charging stations for automated delivery operations.

[![.NET](https://img.shields.io/badge/.NET-5.0-512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-9.0-239120?logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![WPF](https://img.shields.io/badge/WPF-Windows-0078D4?logo=windows)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## 🎯 Features

### Core Functionality
- **Drone Fleet Management** - Monitor and control multiple drones in real-time
- **Parcel Tracking** - End-to-end package delivery lifecycle management
- **Customer Management** - Comprehensive customer database with delivery history
- **Charging Station Network** - Strategic placement and monitoring of drone charging infrastructure
- **Real-time Status Updates** - Live tracking of drone locations, battery levels, and delivery status


### Design Patterns Implemented

#### **Singleton Pattern**
- Ensures single instance of data access managers
- Centralized configuration management
- Thread-safe implementation

#### **Factory Pattern**
- Dynamic object creation for drones, parcels, and customers
- Flexible instantiation based on business rules
- Decoupled object creation logic

#### **Observer Pattern**
- Real-time UI updates on data changes
- Event-driven architecture for drone status updates
- Loose coupling between components

#### **Design by Contract**
- Precondition validation
- Postcondition guarantees
- Invariant enforcement
- Comprehensive input validation

## 🛠️ Technology Stack

- **.NET 5.0** - Core framework
- **C# 9.0** - Programming language
- **WPF (Windows Presentation Foundation)** - UI framework
- **XAML** - UI markup language
- **MVVM Pattern** - UI architectural pattern
- **XML** - Data persistence
- **LINQ** - Data querying and manipulation
- **System.Xml.Serialization** - XML data binding

## 📋 Prerequisites

- **Windows 10/11**
- **.NET 5.0 SDK** or higher
- **Visual Studio 2019/2022** (Community, Professional, or Enterprise)
- **4GB RAM** minimum (8GB recommended)

