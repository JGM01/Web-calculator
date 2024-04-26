# 🧮 ASP.NET Blazor Calculator 🚀
This repository contains a web-based calculator application developed using C# and ASP.NET Blazor. It's designed to reinforce testing concepts and provide valuable coding practice.

## 🛠️ Getting Started
### Prerequisites
- .NET SDK: Ensure you have the .NET SDK installed. Download it from the .NET official website.

### 📦 Installation
Clone the Repository:
```bash
git clone https://github.com/yourusername/blazor-calculator.git
```
Navigate to the Project Directory:
```bash
cd blazor-calculator
```
Restore Dependencies:
```bash
dotnet restore
```
### 🚀 Running the Application
This will locally host the web server which serves the calculator webpage. Access the calculator by navigating to https://localhost:5231 in your web browser.
```bash
dotnet run --project CalculatorWebServerApp
```

### 🤖 Testing
This will run all the tests for the project. 
```bash
dotnet test
```
***NOTE***: The webserver MUST be running for the end-to-end tests to pass.

