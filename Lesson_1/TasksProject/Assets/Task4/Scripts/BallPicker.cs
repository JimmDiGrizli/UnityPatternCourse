using UnityEngine;

namespace Task4.Scripts
{
    public class BallPicker : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (
                _camera is null ||
                Input.GetKey(KeyCode.Mouse0) == false ||
                Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hit) == false
            )
            {
                return;
            }

            hit.transform.TryGetComponent<Ball>(out var ball);
            ball?.Select();
        }
    }
}