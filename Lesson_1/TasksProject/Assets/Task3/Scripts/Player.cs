using System;
using UnityEngine;

namespace Task3.Scripts
{
    public class Player : MonoBehaviour, ISocialize
    {
        [SerializeField] [Range(0, 10)] private int _socialRating = 5;

        public int SocialRating => _socialRating;
        public event Action<int> OnSocialRatingChanged = delegate { };

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeSocialRating(_socialRating - 1);
                OnSocialRatingChanged(SocialRating);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeSocialRating(_socialRating + 1);
                OnSocialRatingChanged(SocialRating);
            }
        }

        private void ChangeSocialRating(int value)
        {
            if (value < 0)
            {
                return;
            }

            _socialRating = value;
        }
    }
}