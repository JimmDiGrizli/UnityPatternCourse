using Task_3.Scripts.VictoryPattern;
using UnityEngine;

namespace Task_3.Scripts
{
    public class Level
    {
        private readonly IVictoryCalculator _victoryCalculator;

        public Level(IVictoryCalculator victoryCalculator)
        {
            _victoryCalculator = victoryCalculator;

            Run();
        }

        private void Run() => _victoryCalculator.OnFinished += Finish;

        private void Finish(bool isSuccess)
        {
            _victoryCalculator.OnFinished -= Finish;
            Debug.Log(isSuccess ? "Победа!" : "Поражение…");
        }
    }
}