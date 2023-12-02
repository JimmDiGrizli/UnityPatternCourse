using System;

namespace Task_4
{
    public interface IEnemyDeathNotifier
    {
        event Action<Enemy.Enemy> DeathNotified;
    }
}
