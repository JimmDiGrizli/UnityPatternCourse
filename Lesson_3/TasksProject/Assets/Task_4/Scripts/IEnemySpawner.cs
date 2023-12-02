using System;

namespace Task_4
{
    public interface IEnemySpawner
    {
        event Action<Enemy.Enemy> Spawned;
        
        void StartWork();
        void StopWork();
    }
}