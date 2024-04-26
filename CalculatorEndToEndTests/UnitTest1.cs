using Microsoft.Playwright;

namespace CalculatorEndToEndTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://localhost:5231/"); // Adjust the URL to your Blazor app's URL
    }
    
    [Test]
    public async Task PageTitleIsCorrect()
    {
        // Get the page title
        string pageTitle = await Page.TitleAsync();

        // Verify the page title
        Assert.That(pageTitle, Is.EqualTo("Calculator"));
    }
    
    [Test]
    public async Task CalculatorAdditionWorksCorrectly()
    {
        // Enter values for A and B
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "5");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "3");

        // Click the addition button
        await Page.ClickAsync("#two-operand-btns button:has-text('A + B')");

        // Verify the result
        var resultText = await Page.TextContentAsync(".result-box p");
        Assert.That(resultText, Is.EqualTo("5 + 3 = \n8"));
    }
    
    [Test]
    public async Task DivisionByZeroShowsErrorState()
    {
        // Enter values for A and B
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "10");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "0");

        // Click the division button
        await Page.ClickAsync("#two-operand-btns button:has-text('A / B')");

        // Verify the result box background color (error state)
        var resultBoxBackgroundColor = await Page.EvalOnSelectorAsync<string>(".result-box", "el => window.getComputedStyle(el).getPropertyValue('background-color')");
        Assert.That(resultBoxBackgroundColor, Is.EqualTo("rgb(183, 15, 10)"));

        // Verify the result text contains "Not a Number"
        var resultText = await Page.TextContentAsync(".result-box p");
        Assert.That(resultText, Does.Contain("Cannot divide by zero"));
    }
    
    /*[Test]
    public async Task InvalidInputShowsErrorState()
    {
        // Enter values for A and B (B is a text value)
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "10");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "fifteen");

        // Click the addition button
        await Page.ClickAsync("#two-operand-btns button:has-text('A + B')");

        // Verify the result box background color (error state)
        var resultBoxBackgroundColor = await Page.EvalOnSelectorAsync<string>(".result-box", "el => window.getComputedStyle(el).getPropertyValue('background-color')");
        Assert.That(resultBoxBackgroundColor, Is.EqualTo("rgb(255, 0, 0)"));

        // Verify the result text contains "Invalid Input, Numbers Only"
        var resultText = await Page.TextContentAsync(".result-box p");
        Assert.That(resultText, Does.Contain("Invalid Input, Numbers Only"));
    }*/
    
    [Test]
    public async Task ClearButtonResetsToDefaultState()
    {
        // Enter values for A and B
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "10");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "5");

        // Click the addition button
        await Page.ClickAsync("#two-operand-btns button:has-text('A + B')");

        // Click the clear button
        await Page.ClickAsync("#header #clear-btn");

        // Verify that Input A is reset to 0
        var input1Value = await Page.InputValueAsync("#input-section-container .textField-container:nth-child(1) .textField");
        Assert.That(input1Value, Is.EqualTo("0"));

        // Verify that Input B is reset to 0
        var input2Value = await Page.InputValueAsync("#input-section-container .textField-container:nth-child(2) .textField");
        Assert.That(input2Value, Is.EqualTo("0"));

        // Verify the result box background color (default state)
        var resultBoxBackgroundColor = await Page.EvalOnSelectorAsync<string>(".result-box", "el => window.getComputedStyle(el).getPropertyValue('background-color')");
        Assert.That(resultBoxBackgroundColor, Is.EqualTo("rgb(255, 236, 215)"));

        // Verify the result text contains "Enter a value(s) below and select an operation."
        var resultText = await Page.TextContentAsync(".result-box p");
        Assert.That(resultText, Is.EqualTo(" = \n0"));
    }
}