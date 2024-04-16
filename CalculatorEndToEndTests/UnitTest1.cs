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
}