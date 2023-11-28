using System;
using UnityEngine;

public class InputService
{
    public event Action DecreaseHealthPressed;
    public event Action UpLevelPressed;

    public void Update()
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