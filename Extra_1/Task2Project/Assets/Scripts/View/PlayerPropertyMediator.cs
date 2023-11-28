using System;

namespace View
{
    public class PlayerPropertyMediator : IDisposable
    {
        private readonly Player _player;
        private readonly Property _property;
        private readonly PlayerPropertyView _view;

        public PlayerPropertyMediator(Player player, Property property, PlayerPropertyView view)
        {
            _player = player;
            _property = property;
            _view = view;

            Initialize();
        }

        public void Dispose()
        {
            _player.Died -= OnDied;
            _property.Changed -= OnChanged;
        }

        private void Initialize()
        {
            _player.Died += OnDied;
            _property.Changed += OnChanged;

            _view.UpdateText(_property.Value);
        }

        private void OnChanged(int value) => _view.UpdateText(value);

        private void OnDied() => _view.Hide();
    }
}