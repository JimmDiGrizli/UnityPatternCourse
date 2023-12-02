using UnityEngine;

namespace Task_4
{
    public class VisitorBootstrap: MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField, Range(1, 100)] private int _weightLimit = 10;

        private Score _score;
        private WeightLimit _weight;

        private void Awake()
        {
            _score = new Score(_spawner);
            _weight = new WeightLimit(_spawner, _spawner, _weightLimit);
            _spawner.StartWork();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space)) 
                _spawner.KillRandomEnemy();
        }

        private void OnDestroy() => _weight.Dispose();
        
    }
}
