using System;

public class Property
{
    private readonly int _initial;
    private int _value;

    public event Action<int> Changed;

    public Property(int value)
    {
        Value = value;
        _initial = value;
    }

    public int Value
    {
        get => _value;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _value = value;
            Changed?.Invoke(Value);
        }
    }

    public void Reset() => Value = _initial;
}