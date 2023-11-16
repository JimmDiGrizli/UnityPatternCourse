using UnityEngine;

namespace Task4.Scripts
{
    public interface IVictoryCalculator
    {
        GameState Calculate(ColorScriptableObject color);
    }
}