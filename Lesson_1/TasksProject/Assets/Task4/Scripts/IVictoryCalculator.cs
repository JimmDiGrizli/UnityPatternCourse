using Task4.Scripts.VictoryPattern;
using UnityEngine;

namespace Task4.Scripts
{
    public interface IVictoryCalculator
    {
        GameState Calculate(Color color);
    }
}