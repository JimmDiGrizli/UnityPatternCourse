using System.Collections.Generic;

namespace Task_1.Scripts.Pause
{
    public class PauseHandler : IPause
    {
        private readonly List<IPause> _handlers = new();

        public void Add(IPause handler) => _handlers.Add(handler);
        public void Remove(IPause handler) => _handlers.Remove(handler);

        public void SetPause(bool isPaused)
        {
            foreach (var handler in _handlers)
            {
                handler.SetPause(isPaused);
            }
        }
    }
}
