using System.Collections.Generic;
using UnityEngine;

namespace Task4.Scripts.VictoryPattern
{
    public class AllBallsCalculator : IVictoryCalculator
    {
        private int _count;

        public AllBallsCalculator(IReadOnlyCollection<Ball> balls)
        {
            _count = balls.Count;
            Debug.Log($"Для победы нужно лопнуть все {_count} шары.");
        }

        public GameState Calculate(Color color)
        {
            return --_count == 0 ? GameState.Win : GameState.InProgress;
        }
    }
}