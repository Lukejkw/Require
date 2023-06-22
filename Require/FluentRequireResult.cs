namespace Require;

public record FluentRequireResult<T>(T Value)
{
    public static implicit operator T(FluentRequireResult<T> d) => d.Value;

    public TDest Map<TDest>(Func<T, TDest> func) => func(Value);
    public void And(Action<T> action) => action(Value);
    public T And(Func<T, T> action) => action(Value);
}