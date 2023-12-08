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

        private void OnValidate()
        {
            if (_mesh == null) _mesh = GetComponent<MeshRenderer>();
        }

        public void Prepare(BallColor ballColor)
        {
            BallColor = ballColor;
            _mesh.material.color = ballColor.Color;
            gameObject.SetActive(true);
        }

        public void Select()
        {
            OnSelected?.Invoke(BallColor);
            Deactivate();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}