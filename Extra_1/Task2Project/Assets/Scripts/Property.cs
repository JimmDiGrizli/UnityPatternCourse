using System;

public class Property<T>
{
    private readonly T _initial;
    private T _value;

    public event Action<T> Changed;

    public Property(T value)
    {
        Value = value;
        _initial = value;
    }

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            Changed?.Invoke(Value);
        }
    }

    public void Reset() => Value = _initial;
}