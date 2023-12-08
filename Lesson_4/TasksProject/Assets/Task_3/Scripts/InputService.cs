using Task_3.Scripts.Balls;
using UnityEngine;
using Zenject;

namespace Task_3.Scripts
{
    public class InputService : ITickable
    {
        public void Tick()
        {
            if (
                UnityEngine.Camera.main is null ||
                Input.GetKey(KeyCode.Mouse0) == false ||
                Physics.Raycast(UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition), out var hit) == false
            )
            {
                return;
            }


            if (hit.transform.TryGetComponent<IBall>(out var ball))
            {
                ball.Select();
            }
        }
    }
}