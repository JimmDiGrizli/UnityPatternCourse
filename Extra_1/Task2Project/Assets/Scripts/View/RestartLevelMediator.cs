using System;

namespace View
{
    public class RestartLevelMediator : IDisposable
    {
        private readonly GamePlay _gamePlay;
        private readonly RestartLevelView _levelView;

        public RestartLevelMediator(GamePlay gamePlay, RestartLevelView levelView)
        {
            _gamePlay = gamePlay;
            _levelView = levelView;

            _gamePlay.Defeat += ShowView;
            _levelView.OnRestartButtonClicked += RestartLevel;
        }

        public void Dispose()
        {
            _levelView.OnRestartButtonClicked -= RestartLevel;
            _gamePlay.Defeat -= RestartLevel;
        }

        private void ShowView() => _levelView.Show();

        private void RestartLevel()
        {
            _levelView.Hide();
            _gamePlay.Restart();
        }
    }
}