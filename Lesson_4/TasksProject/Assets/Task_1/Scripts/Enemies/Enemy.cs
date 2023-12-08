using Task_1.Scripts.Pause;
using Task_1.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Task_1.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IPause
    {
        private int _health;
        private float _speed;

        private IEnemyTarget _target;

        private bool _isPaused;

        [Inject]
        private void Construct(IEnemyTarget target, PauseHandler pauseHandler)
        {
            _target = target;
            pauseHandler.Add(this);
        }

        public virtual void Initialize(int helath, float speed)
        {
            _health = helath;
            _speed = speed;

            Debug.Log($"��: {_health}, ��������: {_speed}");
        }

        private void Update()
        {
            if (_isPaused)
                return;

            var direction = (_target.Position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        public void MoveTo(Vector3 position) => transform.position = position;

        public void SetPause(bool isPaused) => _isPaused = isPaused;
    }
}