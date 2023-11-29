using UnityEngine;

namespace Task2.Scripts.Zones
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Zone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Npc>(out var npc) == false) return;

            Do(npc);
        }

        protected abstract void Do(Npc npc);
    }
}