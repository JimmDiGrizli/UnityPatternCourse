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
                Camera.main is null ||
                Input.GetKey(KeyCode.Mouse0) == false ||
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit) == false
            )
            {
                return;
            }


            if (hit.transform.TryGetComponent<Ball>(out var ball))
            {
                ball.Select();
            }
        }
    }
}