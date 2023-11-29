using System;

namespace View
{
    public class PropertyMediator : IDisposable
    {
        private readonly Property<int> _property;
        private readonly TextView _view;

        public PropertyMediator(Property<int> property, TextView view)
        {
            _property = property;
            _view = view;

            _property.Changed += OnChanged;
            _view.UpdateText(_property.Value);
        }

        public void Dispose() => _property.Changed -= OnChanged;

        private void OnChanged(int value) => _view.UpdateText(value);
    }
}