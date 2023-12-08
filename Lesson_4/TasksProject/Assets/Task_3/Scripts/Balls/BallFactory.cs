using UnityEngine;
using Zenject;

namespace Task_3.Scripts.Balls
{
    public class BallFactory
    {
        private readonly Ball _prefab;
        private readonly DiContainer _container;
        private readonly BallRepository _repository;

        public BallFactory(DiContainer container, BallRepository repository, Ball prefab)
        {
            _container = container;
            _repository = repository;
            _prefab = prefab;
        }

        public Ball CreateTo(Vector3 position, BallColor color)
        {
            var ball = _container.InstantiatePrefabForComponent<Ball>(_prefab, position, Quaternion.identity, null);
            ball.Prepare(color);
            _repository.Add(ball);

            return ball;
        }
    }
}