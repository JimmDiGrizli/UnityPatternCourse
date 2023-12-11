using System.Collections.Generic;
using Task_3.Scripts.Balls;
using UnityEngine;
using Random = System.Random;

namespace Task_3.Scripts.Level
{
    public class GridGenerator
    {
        private readonly BallFactory _factory;
        private readonly LevelData _data;
        private readonly List<BallColor> _colors;

        public GridGenerator(BallFactory factory, LevelData data, IEnumerable<BallColor> colors)
        {
            _factory = factory;
            _data = data;
            _colors = new List<BallColor>(colors);
        }

        public void Build()
        {
            var rnd = new Random();
            for (var i = 0; i < _data.Width; i++)
            {
                for (var j = 0; j < _data.Height; j++)
                {
                    _factory.CreateTo(
                        new Vector3(
                            i * _data.Padding + 1 - _data.Width * _data.Padding / 2.0f,
                            0,
                            j * _data.Padding + 1 - _data.Height * _data.Padding / 2.0f
                        ),
                        _colors[rnd.Next(0, _colors.Count)]
                    );
                }
            }
        }
    }
}