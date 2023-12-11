using System;
using UnityEngine;

namespace Task_3.Scripts.Balls
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Ball : MonoBehaviour, IBall
    {
        public event Action<BallColor> OnSelected;

        private MeshRenderer _mesh;

        public BallColor BallColor { get; private set; }

        public void Prepare(BallColor ballColor)
        {
            if (_mesh == null)
            {
                _mesh = GetComponent<MeshRenderer>();
            }

            BallColor = ballColor;
            _mesh.material.color = BallColor.Color;
        }

        public void Select()
        {
            OnSelected?.Invoke(BallColor);
            gameObject.SetActive(false);
        }
    }
}