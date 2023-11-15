using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task3.Scripts
{
    public class Npc : MonoBehaviour
    {
        private List<ITrader> _behavior;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Player player)) return;

            Debug.Log($"Начал общение с {player}.");

            var traderPattern = _behavior.Last(trader => trader.CanInteract(player));
            if (traderPattern is null)
                throw new InvalidOperationException(nameof(traderPattern));

            traderPattern.Interact(player);
        }

        public void Initialized(IReadOnlyCollection<ITrader> behavior)
        {
            _behavior = new List<ITrader>(behavior);
        }
    }
}