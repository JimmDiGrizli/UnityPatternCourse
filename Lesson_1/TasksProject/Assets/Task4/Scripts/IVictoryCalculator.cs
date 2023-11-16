using System;

namespace Task4.Scripts
{
    public interface IVictoryCalculator
    {
        public event Action<bool> OnFinished;
    }
}