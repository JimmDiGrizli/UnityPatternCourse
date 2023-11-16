using UnityEngine;

namespace Task4.Scripts
{
    public class BallPicker : MonoBehaviour
    {
        private void Update()
        {
            if (
                Input.GetKey(KeyCode.Mouse0) &&
                Physics.Raycast(Camera.main!.ScreenPointToRay(Input.mousePosition), out var hit)
            )
            {
                hit.transform.TryGetComponent<Ball>(out var ball);
                ball?.Select();
            }
        }
    }
}