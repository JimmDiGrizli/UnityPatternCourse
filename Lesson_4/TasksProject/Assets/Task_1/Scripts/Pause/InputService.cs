using UnityEngine;
using Zenject;

namespace Task_1.Scripts.Pause
{
    public class InputService : ITickable
    {
        private readonly PauseHandler _pauseHandler;

        public InputService(PauseHandler pauseHandler)
        {
            _pauseHandler = pauseHandler;
        }

        public void Tick()
        {
            if (Input.GetKeyUp(KeyCode.F))
                _pauseHandler.SetPause(true);

            if (Input.GetKeyUp(KeyCode.S))
                _pauseHandler.SetPause(false);
        }
    }
}
