# KSU SWE 3643 Software Testing and Quality Assurance Semester Project: Web-Based Calculator
This repository contains a web-based calculator application developed using C# and ASP.NET Blazor. It's designed to reinforce testing concepts and provide valuable coding practice.

## Table of Contents
- [Environment](#🖥️-environment)
- [Executing the Web Application](#executing-the-web-application)
- [Executing Unit Tests](#executing-Unit-Tests)
- [Reviewing Unit Test Coverage](#reviewing-Unit-Test-Coverage)
- [Executing End-To-End Tests](#executing-End-To-End-Tests)
- [Final Video Presentation](#final-Video-Presentation)
  
## 🧍‍♂️ Team Members
Jacob Germana-McCray

## 🏛️ Architecture
pictures and descriptions

## 🖥️ Environment
First, check your .NET SDK version. To do so, open your terminal or command prompt and type the following:
```bash
dotnet --version
```
This will show you the version of your .NET SDK. If you see an error, install the SDK by going to the [.NET download page](https://dotnet.microsoft.com/download).

## 🚀 Executing the Web Application

First, clone, enter & set up the dependencies for the repository:
```bash
git clone https://github.com/JGM01/Web-calculator.git
cd web-calculator
dotnet restore
```
After this, you can simply use 
```bash
dotnet run --project CalculatorWebServerApp
```
To launch the web app at the localhost specified in the terminal.

## 🧪 Executing Unit Tests
To Execute the unit tests, remain in the root directory of the project and use the following command:
```bash
dotnet test CalculatorEngineUnitTests
```
This will run all of the unit tests for the CalculatorEngine project.

## 📚 Reviewing Unit Test Coverage
Note the coverage achieved in your Calculator Logic module and include a screenshot of your coverage graphic from your JetBrains IDE. Your calculator logic must achieve 100% test coverage of all statements and paths.

## 🎞️ Executing End-To-End Tests
To execute the end-to-end tests, you must ensure that the `CalculatorWebServerApp` is running. Without this, all the tests will fail.

The preferred way to do this is to open two terminal windows/tabs, and have the Web Server running in one and the following command ran in the other:
```bash
dotnet test CalculatorEngineEndToEndTests
```
This will run all the end-to-end tests.

## 🎥 Final Video Presentation
Include a link to your final video presentation. If the file is checked into your Team Repository, this will be a relative link. Otherwise, it will be a fully-qualified link to YouTube or Vimeo.
