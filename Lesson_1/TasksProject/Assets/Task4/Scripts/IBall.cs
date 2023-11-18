using System;

namespace Task4.Scripts
{
    public interface IBall
    {
        ColorScriptableObject Color { get; }
        event Action<ColorScriptableObject> OnSelected;
        public void Deactivate();
    }
}