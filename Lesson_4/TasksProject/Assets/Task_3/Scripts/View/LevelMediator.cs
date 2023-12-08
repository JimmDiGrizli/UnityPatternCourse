using System;
using Task_3.Scripts.VictoryPattern;

namespace Task_3.Scripts.View
{
    public class LevelMediator : IDisposable
    {
        private readonly Level.Level _level;
        private readonly IVictoryRuleProvider _ruleProvider;
        private readonly GameplayMenuView _menuView;
        private readonly RuleView _ruleView;

        public LevelMediator(Level.Level level, GameplayMenuView menuView, RuleView ruleView)
        {
            _level = level;
            _menuView = menuView;
            _ruleView = ruleView;
            
            _level.OnFinished += ShowMenu;
            _level.OnStarted += ShowRule;
            _menuView.OnResetClicked += RestartLevel;
        }

        private void ShowMenu(bool isSuccess)
        {
            _ruleView.Hide();
            _menuView.Show(isSuccess);
        }

        private void RestartLevel()
        {
            _menuView.Hide();
            _level.Restart();
        }

        private void ShowRule()
        {
            _ruleView.Show();
        }

        public void Dispose()
        {
            _level.OnFinished -= ShowMenu;
            _level.OnStarted += ShowRule;
            _menuView.OnResetClicked -= RestartLevel;
        }
    }
}