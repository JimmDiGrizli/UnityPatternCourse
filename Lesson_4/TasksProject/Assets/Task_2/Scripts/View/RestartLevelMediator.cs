using System;

namespace Task_2.Scripts.View
{
    public class RestartLevelMediator : IDisposable
    {
        private readonly Gameplay _gameplay;
        private readonly RestartLevelView _levelView;

        public RestartLevelMediator(Gameplay gameplay, RestartLevelView levelView)
        {
            _gameplay = gameplay;
            _levelView = levelView;

            _gameplay.Defeat += ShowView;
            _levelView.OnRestartButtonClicked += RestartLevel;
        }

        public void Dispose()
        {
            _levelView.OnRestartButtonClicked -= RestartLevel;
            _gameplay.Defeat -= RestartLevel;
        }

        private void ShowView() => _levelView.Show();

        private void RestartLevel()
        {
            _levelView.Hide();
            _gameplay.Restart();
        }
    }
}