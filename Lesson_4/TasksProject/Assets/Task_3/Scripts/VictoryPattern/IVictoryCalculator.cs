using System;

namespace Task_3.Scripts.VictoryPattern
{
    public interface IVictoryCalculator
    {
        public event Action<bool> OnFinished;
    }
}