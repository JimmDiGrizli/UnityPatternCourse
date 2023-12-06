using System;
using UnityEngine;
using Zenject;

namespace Task_2.Scripts
{
    public class InputService : ITickable
    {
        public event Action DecreaseHealthPressed;
        public event Action UpLevelPressed;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                DecreaseHealthPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                UpLevelPressed?.Invoke();
            }
        }
    }
}