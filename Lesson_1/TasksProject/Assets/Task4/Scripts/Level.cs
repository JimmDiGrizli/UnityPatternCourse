using Task4.Scripts.VictoryPattern;
using UnityEngine;

namespace Task4.Scripts
{
    public class Level
    {
        private VictoryCalculator _victoryCalculator;

        public void Run(VictoryCalculator victoryCalculator)
        {
            if (_victoryCalculator is not null)
            {
                _victoryCalculator.OnFinished -= Finish;
            }

            _victoryCalculator = victoryCalculator;
            _victoryCalculator.OnFinished += Finish;
        }

        private static void Finish(bool isSuccess)
        {
            Debug.Log(isSuccess ? "Победа!" : "Поражение…");
        }
    }
}