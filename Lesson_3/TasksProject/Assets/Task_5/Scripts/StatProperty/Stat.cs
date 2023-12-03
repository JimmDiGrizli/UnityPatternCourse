using System;

namespace Task_5.Scripts.StatProperty
{
    public abstract class Stat
    {
        private int _value;

        protected Stat(int value)
        {
            Value = value;
        }
        
        public int Value
        {
            get => _value;
            private set => _value = Math.Clamp(value, 1, int.MaxValue);
        }

        public static Stat operator+(Stat a, int b)
        {
            a.Value += b;
            return a;
        }

        public static Stat operator-(Stat a, int b)
        {
            a.Value -= b;
            return a;
        }

        public static Stat operator*(Stat a, int b)
        {
            
            a.Value *= b;
            return a;
        }

        public static Stat operator/(Stat a, int b)
        {
            a.Value /= b;
            return a;
        }
    }
}