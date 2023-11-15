using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task4.Scripts.VictoryPattern
{
    public class OneColorCalculator : IVictoryCalculator
    {
        private readonly Color _winColor;
        private int _count;

        public OneColorCalculator(IReadOnlyCollection<IBall> balls)
        {
            _winColor = balls.First().Color;
            _count = balls.Count(ball => ball.Color == _winColor);

            Debug.Log($"Для победы нужно лопнуть все шары с цветом: {_winColor}");
        }

        public GameState Calculate(Color color)
        {
            if (color != _winColor) return GameState.Loose;
            return --_count == 0 ? GameState.Win : GameState.InProgress;
        }
    }
}