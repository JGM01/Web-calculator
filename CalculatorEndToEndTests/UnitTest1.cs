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
    public async Task CalculatorUI_PageTitle_IsCalculator()
    {
        //preq-E2E-TEST-5
        
        // Get the page title
        string title = await Page.TitleAsync();

        // Verify the page title
        Assert.That(title, Is.EqualTo("Calculator"));
    }
    
    [Test]
    public async Task PerformAddition_TwoFloatingNumbers_ShowsSum()
    {
        //preq-E2E-TEST-6
        
        // Enter values for A and B & add.
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "5");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "2");
        await Page.ClickAsync("#two-operand-btns button:has-text('A + B')");

        // Check if the result is correct.
        var resultText = await Page.TextContentAsync(".result-box p");
        Assert.That(resultText, Is.EqualTo("5 + 2 = \n7"));
    }
    
    [Test]
    public async Task PerformDivision_DenominatorIsZero_ShowsError()
    {
        //preq-E2E-TEST-7
        
        // Enter values for A and B & Divide.
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "10");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "0");
        await Page.ClickAsync("#two-operand-btns button:has-text('A / B')");

        // Get result box text & color.
        var resultColor = await Page.EvalOnSelectorAsync<string>(".result-box", "el => window.getComputedStyle(el).getPropertyValue('background-color')");
        var resultText = await Page.TextContentAsync(".result-box p");

        // Check if red & error message shows.
        Assert.That(resultColor, Is.EqualTo("rgb(183, 15, 10)"));
        Assert.That(resultText, Does.Contain("Cannot divide by zero"));
    }
    
    /*[Test]
    public async Task CalculatorUI_StringInput_ShowsError()
    {
        //preq-E2E-TEST-8
        
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
    public async Task ClearButton_OnClick_SetsCalculatorToDefaultState()
    {
        //preq-E2E-TEST-9
        
        // Enter values for A and B & add.
        await Page.FillAsync("#input-section-container .textField-container:nth-child(1) .textField", "10");
        await Page.FillAsync("#input-section-container .textField-container:nth-child(2) .textField", "5");
        await Page.ClickAsync("#two-operand-btns button:has-text('A + B')");

        // Click the clear button
        await Page.ClickAsync("#header #clear-btn");

        // Get values of elements that change when state changes.
        var input1Value = await Page.InputValueAsync("#input-section-container .textField-container:nth-child(1) .textField");
        var input2Value = await Page.InputValueAsync("#input-section-container .textField-container:nth-child(2) .textField");
        var resultColor = await Page.EvalOnSelectorAsync<string>(".result-box", "el => window.getComputedStyle(el).getPropertyValue('background-color')");
        var resultText = await Page.TextContentAsync(".result-box p");

        // Verify that they are set to default values
        Assert.That(input1Value, Is.EqualTo("0"));
        Assert.That(input2Value, Is.EqualTo("0"));
        Assert.That(resultColor, Is.EqualTo("rgb(255, 236, 215)"));
        Assert.That(resultText, Is.EqualTo(" = \n0"));
    }
}