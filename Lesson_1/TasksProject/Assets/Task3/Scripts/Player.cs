using UnityEngine;

namespace Task3.Scripts
{
    public class Player : MonoBehaviour, ISocialize
    {
        [SerializeField] [Range(0, 10)] private int _socialRating = 5;

        public int SocialRating => _socialRating;
    }
}