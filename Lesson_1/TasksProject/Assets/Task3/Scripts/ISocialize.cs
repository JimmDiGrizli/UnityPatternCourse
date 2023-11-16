using System;

namespace Task3.Scripts
{
    public interface ISocialize
    {
        int SocialRating { get; }
        public event Action<int> OnSocialRatingChanged;
    }
}