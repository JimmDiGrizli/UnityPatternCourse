using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task_3.Scripts.Balls
{
    public class BallRepository
    {
        private readonly List<Ball> _balls = new();

        public void Add(Ball ball) => _balls.Add(ball);

        public int Count(Func<IBall, bool> action = null) => action != null ? _balls.Count(action) : _balls.Count;

        public IBall Random() => _balls[0];

        public IEnumerable<IBall> FindAll() => _balls;

        public void RemoveAll()
        {
            foreach (var ball in _balls)
            {
                GameObject.Destroy(ball.gameObject);
            }

            _balls.Clear();
        }
    }
}