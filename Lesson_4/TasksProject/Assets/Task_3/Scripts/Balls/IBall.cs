using System;

namespace Task_3.Scripts.Balls
{
    public interface IBall
    {
        BallColor BallColor { get; }
        event Action<BallColor> OnSelected;
        void Select();
    }
}