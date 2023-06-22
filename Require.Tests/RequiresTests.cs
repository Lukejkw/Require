using Require;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Require.Tests;

[TestFixture]
public class RequiresTests
{
    [Test]
    public void NotNull_GivenNull_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Requires.NotNull<object>(null));
    }

    [Test]
    public void NotNull_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = new object();
        var result = Requires.NotNull(value);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndNotNull_GivenNull_ShouldThrowArgumentNullException()
    {
        object? stubObject = null;
        Assert.Throws<ArgumentNullException>(() => new FluentRequireResult<object>(stubObject!).AndNotNull());
    }

    [Test]
    public void AndNotNull_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = new object();
        var result = new FluentRequireResult<object>(value).AndNotNull();
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void NotNullOrWhiteSpace_GivenNull_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Requires.NotNullOrWhiteSpace(null));
    }

    [Test]
    public void NotNullOrWhiteSpace_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = "valid";
        var result = Requires.NotNullOrWhiteSpace(value);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void NotNullOrWhiteSpace_GivenEmptyString_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Requires.NotNullOrWhiteSpace(string.Empty));
    }

    [Test]
    public void NotNullOrWhiteSpace_GivenWhiteSpace_ShouldThrowArgumentException()
    {
        const string whitespace = "   ";
        Assert.Throws<ArgumentException>(() => Requires.NotNullOrWhiteSpace(whitespace));
    }

    [Test]
    public void AndNotNullOrWhiteSpace_GivenNull_ShouldThrowArgumentNullException()
    {
        string? stubObject = null;
        Assert.Throws<ArgumentNullException>(
            () => new FluentRequireResult<string>(stubObject!).AndNotNullOrWhiteSpace());
    }

    [Test]
    public void AndNotNullOrWhiteSpace_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = "valid";
        var result = new FluentRequireResult<string>(value).AndNotNullOrWhiteSpace();
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndNotNullOrWhiteSpace_GivenEmptyString_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new FluentRequireResult<string>(string.Empty).AndNotNullOrWhiteSpace());
    }

    [Test]
    public void AndNotNullOrWhiteSpace_GivenWhiteSpace_ShouldThrowArgumentException()
    {
        const string whitespace = "   ";
        Assert.Throws<ArgumentException>(() => new FluentRequireResult<string>(whitespace).AndNotNullOrWhiteSpace());
    }

    [Test]
    public void NotDefault_GivenDefaultDateTime_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Requires.NotDefault<DateTime>(default));
    }

    [Test]
    public void NotDefault_GivenValidDateTime_ShouldNotThrowArgumentException()
    {
        Assert.DoesNotThrow(() => Requires.NotDefault(DateTime.Now));
    }

    [Test]
    public void NotDefault_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = DateTime.Now;
        var result = Requires.NotDefault(value);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndNotDefault_GivenDefaultDateTime_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new FluentRequireResult<DateTime>(default).AndNotDefault());
    }

    [Test]
    public void AndNotDefault_GivenValidDateTime_ShouldNotThrowArgumentException()
    {
        Assert.DoesNotThrow(() => new FluentRequireResult<DateTime>(DateTime.Now).AndNotDefault());
    }

    [Test]
    public void AndNotDefault_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = DateTime.Now;
        var result = new FluentRequireResult<DateTime>(value).AndNotDefault();
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void NotNullOrEmpty_GivenNull_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentNullException>(() => Requires.NotNullOrEmpty(default(List<object>)));
    }

    [Test]
    public void NotNullOrEmpty_GivenEmptyString_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Requires.NotNullOrEmpty(new List<object>()));
    }

    [Test]
    public void NotNullOrEmpty_GivenPopulatedCollection_ShouldNotThrow()
    {
        Assert.DoesNotThrow(
            () => Requires.NotNullOrEmpty(new List<object> { new() }));
    }

    [Test]
    public void NotNullOrEmpty_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = new List<object> { new() };
        var result = Requires.NotNullOrEmpty(value);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndNotNullOrEmpty_GivenNull_ShouldThrowArgumentException()
    {
        List<object>? stubObject = null;
        Assert.Throws<ArgumentNullException>(
            () => new FluentRequireResult<List<object>>(stubObject!).AndNotNullOrEmpty());
    }

    [Test]
    public void AndNotNullOrEmpty_GivenEmptyString_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new FluentRequireResult<List<object>>(new List<object>()).AndNotNullOrEmpty());
    }

    [Test]
    public void AndNotNullOrEmpty_GivenPopulatedCollection_ShouldNotThrow()
    {
        Assert.DoesNotThrow(
            () => new FluentRequireResult<List<object>>(new List<object> { new() }).AndNotNullOrEmpty());
    }

    [Test]
    public void AndNotNullOrEmpty_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = new List<object> { new() };
        var result = new FluentRequireResult<List<object>>(value).AndNotNullOrEmpty();
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void NotNegative_GivenPositiveNumber_ShouldNotThrow()
    {
        Assert.DoesNotThrow(
            () => Requires.NotNegative(1));
    }

    [Test]
    public void NotNegative_GivenDefault_ShouldNotThrow()
    {
        Assert.DoesNotThrow(
            () => Requires.NotNegative(default));
    }

    [Test]
    public void NotNegative_GivenNegative_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Requires.NotNegative(-1));
    }

    [Test]
    public void NotNegative_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 100;
        var result = Requires.NotNegative(value);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndNotNegative_GivenDefault_ShouldNotThrow()
    {
        Assert.DoesNotThrow(
            () => new FluentRequireResult<int>(default).AndNotNegative());
    }

    [Test]
    public void AndNotNegative_GivenNegative_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new FluentRequireResult<int>(-1).AndNotNegative());
    }

    [Test]
    public void AndNotNegative_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 100;
        var result = new FluentRequireResult<int>(value).AndNotNegative();
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void To_GivenValidFluentAssertion_ShouldConvertType()
    {
        Assert.IsTrue(Requires.NotNull("1").Map(_ => true));
    }

    [Test]
    public void To_GivenInvalidFluentAssertion_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(
            () => Requires.NotNull<object>(null).Map(_ => true));
    }

    [Test]
    public void Min_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 8;
        var minValue = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Min(value, minValue));
    }

    [Test]
    public void Min_GivenValidFluentAssertion_ShouldNotThrow()
    {
        var value = 12;
        var minValue = 10;
        Assert.DoesNotThrow(() => Requires.Min(value, minValue));
    }

    [Test]
    public void AndMin_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 12;
        var result = new FluentRequireResult<int>(value).AndMin(10);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndMin_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 8;
        var minValue = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() => new FluentRequireResult<int>(value).AndMin(minValue));
    }

    [Test]
    public void Max_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 12;
        var maxValue = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Max(value, maxValue));
    }

    [Test]
    public void Max_GivenValidFluentAssertion_ShouldNotThrow()
    {
        var value = 8;
        var maxValue = 10;
        Assert.DoesNotThrow(() => Requires.Max(value, maxValue));
    }

    [Test]
    public void AndMax_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 8;
        var result = new FluentRequireResult<int>(value).AndMax(10);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndMax_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 12;
        var maxValue = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() => new FluentRequireResult<int>(value).AndMax(maxValue));
    }

    [Test]
    [TestCase(7)]
    [TestCase(11)]
    public void InRange_GivenInvalidFluentAssertion_ShouldThrow(int value)
    {
        var minValue = 8;
        var maxValue = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() => Requires.InRange(value, minValue, maxValue));
    }

    [Test]
    public void InRange_GivenValidFluentAssertion_ShouldNotThrow()
    {
        var value = 9;
        var minValue = 8;
        var maxValue = 10;
        Assert.DoesNotThrow(() => Requires.InRange(value, minValue, maxValue));
    }

    [Test]
    public void AndInRange_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 9;
        var minValue = 8;
        var maxValue = 10;
        var result = new FluentRequireResult<int>(value).AndInRange(minValue, maxValue);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    [TestCase(7)]
    [TestCase(11)]
    public void AndInRange_GivenInvalidFluentAssertion_ShouldThrow(int value)
    {
        var minValue = 8;
        var maxValue = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new FluentRequireResult<int>(value).AndInRange(minValue, maxValue));
    }

    [Test]
    public void MinDecimal_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 8m;
        var minValue = 8.1m;
        Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Min(value, minValue));
    }

    [Test]
    public void MinDecimal_GivenValidFluentAssertion_ShouldNotThrow()
    {
        var value = 10.1m;
        var minValue = 10m;
        Assert.DoesNotThrow(() => Requires.Min(value, minValue));
    }

    [Test]
    public void AndMinDecimal_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 12m;
        var result = new FluentRequireResult<decimal>(value).AndMin(10m);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndMinDecimal_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 9.9m;
        var minValue = 10m;
        Assert.Throws<ArgumentOutOfRangeException>(() => new FluentRequireResult<decimal>(value).AndMin(minValue));
    }

    [Test]
    public void MaxDecimal_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 10.1m;
        var maxValue = 10m;
        Assert.Throws<ArgumentOutOfRangeException>(() => Requires.Max(value, maxValue));
    }

    [Test]
    public void MaxDecimal_GivenValidFluentAssertion_ShouldNotThrow()
    {
        var value = 9.9m;
        var maxValue = 10m;
        Assert.DoesNotThrow(() => Requires.Max(value, maxValue));
    }

    [Test]
    public void AndMaxDecimal_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 8m;
        var result = new FluentRequireResult<decimal>(value).AndMax(10m);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    public void AndMaxDecimal_GivenInvalidFluentAssertion_ShouldThrow()
    {
        var value = 10.1m;
        var maxValue = 10m;
        Assert.Throws<ArgumentOutOfRangeException>(() => new FluentRequireResult<decimal>(value).AndMax(maxValue));
    }

    [Test]
    [TestCase(7.9)]
    [TestCase(11.1)]
    public void InRangeDecimal_GivenInvalidFluentAssertion_ShouldThrow(decimal value)
    {
        var minValue = 8m;
        var maxValue = 10m;
        Assert.Throws<ArgumentOutOfRangeException>(() => Requires.InRange(value, minValue, maxValue));
    }

    [Test]
    public void InRangeDecimal_GivenValidFluentAssertion_ShouldNotThrow()
    {
        var value = 9m;
        var minValue = 8.9m;
        var maxValue = 9.1m;
        Assert.DoesNotThrow(() => Requires.InRange(value, minValue, maxValue));
    }

    [Test]
    public void AndInRangeDecimal_GivenValidValue_ShouldReturnFluentResult()
    {
        var value = 8m;
        var minValue = 8m;
        var maxValue = 10m;
        var result = new FluentRequireResult<decimal>(value).AndInRange(minValue, maxValue);
        Assert.AreEqual(value, result.Value);
    }

    [Test]
    [TestCase(7)]
    [TestCase(11)]
    public void AndInRangeDecimal_GivenInvalidFluentAssertion_ShouldThrow(decimal value)
    {
        var minValue = 8m;
        var maxValue = 10m;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new FluentRequireResult<decimal>(value).AndInRange(minValue, maxValue));
    }

    [Test]
    public void In_GivenStringValueNotInCollection_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => Requires.In(new List<string>(), "missing value"));
    }
    
    [Test]
    public void In_GivenIntValueNotInCollection_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => Requires.In(new List<int>(), 1));
    }
    
    [Test]
    public void AndIn_GivenIntValueNotInCollection_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new FluentRequireResult<int>(1).AndIn(new List<int>()));
    }

    [Test]
    public void In_GivenStringValueInCollection_ShouldReturnFluentRequireResult()
    {
        var value = "value";

        var result = Requires.In(new List<string> { value }, value);

        Assert.IsInstanceOf<FluentRequireResult<string>>(result);
        Assert.AreEqual(value, result.Value);
    }
    
    [Test]
    public void In_GivenIntValueInCollection_ShouldReturnFluentRequireResult()
    {
        var value = 1;

        var result = Requires.In(new List<int> { value }, value);

        Assert.IsInstanceOf<FluentRequireResult<int>>(result);
        Assert.AreEqual(value, result.Value);
    }
    
    [Test]
    public void AndIn_GivenIntValueInCollection_ShouldReturnFluentRequireResult()
    {
        var value = 1;

        var result = new FluentRequireResult<int>(value).AndIn(new List<int> { value });

        Assert.IsInstanceOf<FluentRequireResult<int>>(result);
        Assert.AreEqual(value, result.Value);
    }
}