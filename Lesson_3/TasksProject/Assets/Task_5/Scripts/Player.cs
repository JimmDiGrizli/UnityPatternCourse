using Task_5.Scripts.StatProperty;
using Task_5.Scripts.StatProvider;
using UnityEngine;

namespace Task_5.Scripts
{
    public class Player
    {
        private readonly string _name;
        private readonly IStatProvider _statProvider;

        public Player(string name, IStatProvider statProvider)
        {
            _name = name;
            _statProvider = statProvider;
        }

        public void PrintStat()
        {
            Debug.Log($"Player: {_name}");
            
            var intellectStat = _statProvider.GetStat<IntellectStat>();

            if (intellectStat is not null)
            {
                Debug.Log($"Intellect: {intellectStat.Value}");
            }

            var agilityStat = _statProvider.GetStat<AgilityStat>();

            if (agilityStat is not null)
            {
                Debug.Log($"Agility: {agilityStat.Value}");
            }

            var strengthStat = _statProvider.GetStat<StrengthStat>();

            if (agilityStat is not null)
            {
                Debug.Log($"Strength: {strengthStat.Value}");
            }

            var humanSpecialStat = _statProvider.GetStat<HumanSpecialStat>();

            if (humanSpecialStat is not null)
            {
                Debug.Log($"HumanSpecial: {humanSpecialStat.Value}");
            }
        }
    }
}