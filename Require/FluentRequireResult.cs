namespace Require;

public record FluentRequireResult<T>(T Value)
{
    public static implicit operator T(FluentRequireResult<T> d) => d.Value;

    /// <summary>
    /// Applies the given transformation function to the validated value.
    /// </summary>
    /// <param name="func">Function transformation expression</param>
    /// <typeparam name="TDest">Target type</typeparam>
    /// <returns></returns>
    public TDest Map<TDest>(Func<T, TDest> func) => func(Value);
    
    /// <summary>
    /// Do something with the value post-assertion
    /// </summary>
    /// <param name="action"></param>
    public void Then(Action<T> action) => action(Value);

    /// <summary>
    /// Generic catch all assertion. Throws if predicate returns false based on value
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public FluentRequireResult<T> And(Func<T, bool> predicate)
    {
        bool isValid = predicate(Value);
        
        // TODO: Improve error message
        return isValid ? this : throw new ArgumentException();
    }
}