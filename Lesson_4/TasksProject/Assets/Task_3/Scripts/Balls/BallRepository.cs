using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Task_3.Scripts.Balls
{
    public class BallRepository
    {
        private readonly List<BallColor> _colors;
        private readonly Ball[] _balls;

        public BallRepository(IEnumerable<BallColor> colors)
        {
            _colors = new List<BallColor>(colors);
            _balls = GameObject.FindObjectsOfType<Ball>();

            PrepareBalls();
        }

        public int Count(Func<Ball, bool> action = null) => action != null ? _balls.Count(action) : _balls.Length;

        public BallColor Random() => _balls[0].BallColor;

        public IEnumerable<Ball> FindAll() => _balls;

        private void PrepareBalls()
        {
            var rnd = new Random();
            foreach (var ball in FindAll())
            {
                ball.Prepare(_colors[rnd.Next(0, _colors.Count)]);
            }
        }
    }
}