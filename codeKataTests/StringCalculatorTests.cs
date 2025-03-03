using CalculatorProgram;
using Xunit.Abstractions;

namespace codeKata;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator = new();
    private readonly ITestOutputHelper _output;
    
    public StringCalculatorTests(ITestOutputHelper output)
    {
        _output = output;
    }
    
    [Fact]
    public void EmptyStringReturnsZero()
    {
        Assert.Equal(0, _calculator.Calculate(""));
    }
    
    [Fact]
    public void SingleNumberReturnsValue()
    {
        Assert.Equal(5, _calculator.Calculate("5"));
    }
    
    [Fact]
    public void TwoNumbersCommaDelimitedReturnsSum()
    {
        Assert.Equal(8, _calculator.Calculate("3,5"));
    }
    
    [Fact]
    public void TwoNumbersNewlineDelimitedReturnsSum()
    {
        Assert.Equal(8, _calculator.Calculate("3\n5"));
    }
    
    [Fact]
    public void ThreeNumbersDelimitedByNewLineOrCommaReturnsSum()
    {
        Assert.Equal(16, _calculator.Calculate("3,5\n8"));
    }
    
    [Fact]
    public void NegativeNumbersThrowException()
    {
        var ex = Assert.Throws<ArgumentException>(() => _calculator.Calculate("-1,-2,3"));
    }
    
    [Fact]
    public void NumbersGreaterThan1000AreIgnored()
    {
        Assert.Equal(2, _calculator.Calculate("2,1001"));
    }

    [Fact]
    public void CustomSingleCharDelimiterWorks()
    {
        Assert.Equal(3, _calculator.Calculate("//#\n1#2"));
    }

    [Fact]
    public void CustomMultiCharDelimiterWorks()
    {
        Assert.Equal(6, _calculator.Calculate("//[###]\n1###2###3"));
    }

    [Fact]
    public void MultipleCustomDelimitersWork()
    {
        Assert.Equal(6, _calculator.Calculate("//[;][***]\n1;2***3"));
    }
}