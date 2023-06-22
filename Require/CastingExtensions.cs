namespace Require;

public static class CastingExtensions
{
    public static T Cast<T>(this object obj) where T : class => 
        obj as T ?? throw new InvalidCastException();
    
    public static IEnumerable<T> Cast<T>(this IEnumerable<object> objects) => 
        Enumerable.Cast<T>(objects);
}