# Require

A simple lightweight fluent assertion library.

## Features

* Fully tested
* Readable error messages
* Correct argument exceptions based on assertion type
* Fluent api for simple "one-liner" assertions
* Map to destination type assuming validity
* Implicit assignment
* Easily plug in your favourite validation or add custom validators

## Why?

Yes, other libraries exist. Sometimes you just need something stupidly simple to use. There is a [Guard Class](https://learn.microsoft.com/en-us/dotnet/api/microsoft.toolkit.diagnostics.guard?view=win-comm-toolkit-dotnet-7.0) in modern versions of .NET but it isn't fluent. FluentAssertions is great but is arguably much more than you need for simple things.

## Getting Started

All the methods stem from the calling a static assertion on the `Requires` class. From there, simply chain further assertion calls. Every method has a corresponding `And{Method}` for chaining.

If an assertion fails, an exception is thrown. If not, you can assume it's valid.

### Usage

```csharp
// Validate the response with implicit assignment back to the target type
string value = Requires.NotNull("")
    .AndNotDefault(); // Look ma, no param!

// Map data post-assertion using Map method
string unwrappedValue = Requires.NotNull(new Example("NestedValue"))
    .Map(v => v.NestedProp);
    
// Then will only be called if all assertions pass
Requires.NotNull(new Example("NestedValue"))
    .Then(v => { /* Ah! This feels like JavaScript! */ });
```

> **Note:** There are many other assertion methods available for `object` references, `string`s, `int`s, `decimal`s,`IEnumberable`s etc. Missing something? See advanced usage and contribution guidelines.

### Advanced Usage

"Advanced" seems a bit much - this isn't rocket-science. However, if you're missing an assertion method, all is not lost! You have a couple options without needing to break out of the fluent assertion chain.

> **Pro Tip:** These are also a cool way to integrate the built in [`Guard` class methods](https://learn.microsoft.com/en-us/dotnet/api/microsoft.toolkit.diagnostics.guard?view=win-comm-toolkit-dotnet-7.0)

### Generic `And` Fallback

```csharp
// This will throw if the value is equal to "bucket of cheese"
Require.NotNull("").And(v => v != "bucket of cheese")
```

###  Extension Method

```csharp
public static FluentRequireResult<string> AndNotBucketOfCheese(this FluentRequireResult<string> fluentResult) => fluentResult.Value != "bucket of cheese"
```

## Contributing/Questions

Please create an issue for any questions, bugs and feature requests.

## Roadmap

Things I'd like to do:

* Separate each method into it's own file so that Requires isn't so big
* Separate each method's tests into it's own file too