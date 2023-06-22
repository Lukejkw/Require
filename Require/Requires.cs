using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Require;

public static class Requires
{
    /// <summary>
    /// Asserts that the value is not the default(T)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    [return: NotNull]
    public static FluentRequireResult<T> NotDefault<T>(T value, [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value != null && value.Equals(default(T)))
        {
            throw new ArgumentException("Cannot be default", paramName);
        }

        return new FluentRequireResult<T>(value);
    }

    /// <summary>
    /// Asserts that the value is not the default(T)
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static FluentRequireResult<T> AndNotDefault<T>(this FluentRequireResult<T> chain)
    {
        NotDefault(chain.Value);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is not null and casts to the target type
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [return: NotNull]
    public static FluentRequireResult<T> NotNull<T>([NotNull] T? value, [CallerArgumentExpression("value")] string paramName = "") where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        return new FluentRequireResult<T>(value.Cast<T>());
    }

    /// <summary>
    /// Asserts that the value is not null
    /// </summary>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static FluentRequireResult<object> AndNotNull(this FluentRequireResult<object> chain)
    {
        NotNull(chain.Value);
        return chain;
    }

    /// <summary>
    /// Asserts that there are no duplicates in a collection
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static FluentRequireResult<List<T>> NoDuplicates<T>(
        List<T>? value, 
        [CallerArgumentExpression("value")] string paramName = "")
    {
        var list = value?.ToList();

        if (list is null)
        {
            throw new ArgumentNullException(paramName);
        }

        if (list.Distinct().Count() != list.Count)
        {
            throw new ArgumentException("Cannot be duplicated", paramName);
        }

        return new FluentRequireResult<List<T>>(list);
    }

    /// <summary>
    /// Asserts that there are no duplicates in a collection
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static FluentRequireResult<List<T>> AndNoDuplicates<T>(this FluentRequireResult<List<T>> chain)
    {
        NoDuplicates(chain.Value);
        return chain;
    }

    /// <summary>
    /// Asserts that the supplied string value is not null or whitespace
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    [return: NotNull]
    public static FluentRequireResult<string> NotNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Cannot be whitespace", paramName);
        }

        return new FluentRequireResult<string>(value);
    }

    /// <summary>
    /// Asserts that the value does not contain the supplied character
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static FluentRequireResult<string> AndContains(this FluentRequireResult<string> chain, char value)
    {
        if (!chain.Value.Contains(value))
        {
            throw new ArgumentException($"'{chain.Value}' does not contain '{value}'");
        }

        return chain;
    }
    
    /// <summary>
    /// Asserts that the supplied string value is not null or whitespace
    /// </summary>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static FluentRequireResult<string> AndNotNullOrWhiteSpace(this FluentRequireResult<string> chain)
    {
        NotNullOrWhiteSpace(chain.Value);
        return chain;
    }

    /// <summary>
    /// Asserts that the collection is not null and contains at least 1 item
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    [return: NotNull]
    public static FluentRequireResult<List<T>> NotNullOrEmpty<T>([NotNull] List<T>? value, [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        var materializedCollection = value.ToList();

        if (!materializedCollection.Any())
        {
            throw new ArgumentException("Cannot be empty", paramName);
        }

        return new FluentRequireResult<List<T>>(materializedCollection);
    }
    
    /// <summary>
    /// Asserts that the collection is not null and contains at least 1 item
    /// </summary>
    /// <param name="chain"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [return: NotNull]
    public static FluentRequireResult<List<T>> AndNotNullOrEmpty<T>(this FluentRequireResult<List<T>> chain)
    {
        NotNullOrEmpty(chain.Value);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is greater than or equal to 0
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<int> NotNegative(int value, [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value < default(int))
        {
            throw new ArgumentOutOfRangeException(paramName, "Cannot be negative");
        }

        return new FluentRequireResult<int>(value);
    }
    
    /// <summary>
    /// Asserts that the value is greater than or equal to 0
    /// </summary>
    /// <param name="value"></param>
    /// <param name="paramName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<decimal> NotNegative(decimal value, [CallerArgumentExpression("value")] string paramName = "")
    {
        if (value < default(int))
        {
            throw new ArgumentOutOfRangeException(paramName, "Cannot be negative");
        }

        return new FluentRequireResult<decimal>(value);
    }

    /// <summary>
    /// Asserts that the value is greater than or equal to 0
    /// </summary>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static FluentRequireResult<int> AndNotNegative(this FluentRequireResult<int> chain)
    {
        NotNegative(chain.Value);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is not smaller than the supplied value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<int> Min(int value, int minValue)
    {
        if (value < minValue)
        {
            throw new ArgumentOutOfRangeException($"Value cannot be less than {minValue}");
        }

        return new FluentRequireResult<int>(value);
    }

    /// <summary>
    /// Asserts that the value is not smaller than the supplied value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<string> Min(string value, int minValue)
    {
        if (value.Length < minValue)
        {
            throw new ArgumentOutOfRangeException($"Value cannot have less characters than {minValue}");
        }

        return new FluentRequireResult<string>(value);
    }

    /// <summary>
    /// Asserts that the value is not smaller than the supplied value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<decimal> Min(decimal value, decimal minValue)
    {
        if (value < minValue)
        {
            throw new ArgumentOutOfRangeException($"Value cannot be less than {minValue}");
        }

        return new FluentRequireResult<decimal>(value);
    }

    /// <summary>
    /// Asserts that the value is not smaller than the supplied value
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<int> AndMin(this FluentRequireResult<int> chain, int minValue)
    {
        Min(chain.Value, minValue);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is not smaller than the supplied value
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="minValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<decimal> AndMin(this FluentRequireResult<decimal> chain, decimal minValue)
    {
        Min(chain.Value, minValue);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is not larger than the supplied value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<int> Max(int value, int maxValue)
    {
        if (value > maxValue)
        {
            throw new ArgumentOutOfRangeException($"Value cannot be more than {maxValue}");
        }

        return new FluentRequireResult<int>(value);
    }

    /// <summary>
    /// Asserts that the value is not larger than the supplied value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<string> Max(string value, int maxValue)
    {
        if (value.Length > maxValue)
        {
            throw new ArgumentOutOfRangeException($"Value cannot be more than {maxValue}");
        }

        return new FluentRequireResult<string>(value);
    }

    /// <summary>
    /// Asserts that the value is not larger than the supplied value
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static FluentRequireResult<decimal> Max(decimal value, decimal maxValue)
    {
        if (value > maxValue)
        {
            throw new ArgumentOutOfRangeException($"Value must have more characters than {maxValue}");
        }

        return new FluentRequireResult<decimal>(value);
    }

    /// <summary>
    /// Asserts that the value is not larger than the supplied value
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<int> AndMax(this FluentRequireResult<int> chain, int maxValue)
    {
        Max(chain.Value, maxValue);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is not larger than the supplied value
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<decimal> AndMax(this FluentRequireResult<decimal> chain, decimal maxValue)
    {
        Max(chain.Value, maxValue);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is between the min and maximum bounds defined
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<int> InRange(int value, int minValue, int maxValue)
    {
        Max(value, maxValue);
        Min(value, minValue);

        return new FluentRequireResult<int>(value);
    }

    /// <summary>
    /// Asserts that the value is between the min and maximum bounds defined
    /// </summary>
    /// <param name="value"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<decimal> InRange(decimal value, decimal minValue, decimal maxValue)
    {
        Max(value, maxValue);
        Min(value, minValue);

        return new FluentRequireResult<decimal>(value);
    }

    /// <summary>
    /// Asserts that the value is between the min and maximum bounds defined
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<int> AndInRange(this FluentRequireResult<int> chain, int minValue, int maxValue)
    {
        Max(chain.Value, maxValue);
        Min(chain.Value, minValue);
        return chain;
    }

    /// <summary>
    /// Asserts that the value is between the min and maximum bounds defined
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static FluentRequireResult<decimal> AndInRange(this FluentRequireResult<decimal> chain, decimal minValue, decimal maxValue)
    {
        Max(chain.Value, maxValue);
        Min(chain.Value, minValue);
        return chain;
    }
    
    /// <summary>
    /// Asserts that the value is in the supplied collection.
    ///
    /// Value types use value based equality while reference types use reference based equality (unless the record type is used)
    /// </summary>
    /// <param name="referenceCollection"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static FluentRequireResult<T> In<T>(IEnumerable<T> referenceCollection, T value)
    {
        var materialisedCollection = referenceCollection.ToList();
        
        if (materialisedCollection.All(x => x != null && !x.Equals(value)))
        {
            throw new ArgumentException(
                $"'{value}' is not a valid option. Must be one of '{string.Join(", ", materialisedCollection.ToList())}'");
        }

        return new FluentRequireResult<T>(value);
    }
    
    /// <summary>
    /// Asserts that the value is in the supplied collection.
    ///
    /// Value types use value based equality while reference types use reference based equality (unless the record type is used)
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="referenceCollection"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static FluentRequireResult<T> AndIn<T>(this FluentRequireResult<T> chain, IEnumerable<T> referenceCollection) => 
        In(referenceCollection, chain.Value);
}