using System;

namespace View
{
    public class RestartLevelMediator : IDisposable
    {
        private readonly Level _level;
        private readonly RestartLevelView _levelView;

        public RestartLevelMediator(Level level, RestartLevelView levelView)
        {
            _level = level;
            _levelView = levelView;
        
            _level.Defeat += ShowView;
            _levelView.OnRestartButtonClicked += RestartLevel;
        }

        public void Dispose()
        {
            _levelView.OnRestartButtonClicked -= RestartLevel;
            _level.Defeat -= RestartLevel;
        }

        private void ShowView()
        {
            _levelView.Show();
        }

        private void RestartLevel()
        {
            _levelView.Hide();
            _level.Restart();
        }
    }
}