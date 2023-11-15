using UnityEngine;

namespace Task2.Scripts
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] [Range(2, 10)] private float _speed = 5.0f;

        private void Start()
        {
             Destroy(gameObject, 3.0f);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        }
    }
}