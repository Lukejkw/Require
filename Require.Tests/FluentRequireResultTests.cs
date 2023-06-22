using System;
using NUnit.Framework;

namespace Require.Tests;

public class FluentRequireResultTests
{
    [Test]
    public void ImplicitCast_ShouldUnwrapValue()
    {
        int result = new FluentRequireResult<int>(1);
        
        Assert.AreEqual(1, result);
    }
    
    [Test]
    public void Map_GivenValidFluentAssertion_ShouldConvertType()
    {
        Assert.IsTrue(Requires.NotNull("1").Map(_ => true));
    }

    [Test]
    public void Map_GivenInvalidFluentAssertion_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(
            () => Requires.NotNull<object>(null).Map(_ => true));
    }
    
    [Test]
    public void Then_GivenValidFluentAssertion_ShouldRunFunction()
    {
        string inputValue = "1";
        bool ran = false;
        Requires.NotNull(inputValue).Then(v => ran = inputValue == v);
        Assert.IsTrue(ran);
    }

    [Test]
    public void Then_GivenInvalidFluentAssertion_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(
            () => Requires.NotNull<object>(null).Then(_ => {}));
    }
    
    [Test]
    public void And_GivenValidFluentAssertion_ShouldRunFunction()
    {
        string inputValue = "valid";

        var result = Requires.NotNull(inputValue).And(v => v != "invalid");
        
        Assert.IsInstanceOf<FluentRequireResult<string>>(result);
        Assert.AreEqual(inputValue, result.Value);
    }

    [Test]
    public void And_GivenInvalidFluentAssertion_ShouldThrow()
    {
        string inputValue = "invalid";

        Assert.Throws<ArgumentException>(
            () => Requires.NotNull(inputValue).And(v => v != "invalid"));
    }
}