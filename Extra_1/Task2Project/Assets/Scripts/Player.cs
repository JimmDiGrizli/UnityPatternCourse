using System;

public class Player
{
    private readonly Property _healthPoint;
    private readonly Property _level;

    public event Action Died;

    public Player(Property healthPoint, Property level)
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