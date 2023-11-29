using System;

public class Player
{
    private readonly Property<int> _healthPoint;
    private readonly Property<int> _level;

    public event Action Died;

    public Player(Property<int> healthPoint, Property<int> level)
    {
        _healthPoint = healthPoint;
        _level = level;
    }

    public void Restart()
    {
        _healthPoint.Reset();
        _level.Reset();
    }

    public void UpLevel() => _level.Value++;

    public void DecreaseHealth()
    {
        if (_healthPoint.Value <= 0)
        {
            return;
        }

        _healthPoint.Value--;

        if (_healthPoint.Value == 0)
        {
            Died?.Invoke();
        }
    }
}