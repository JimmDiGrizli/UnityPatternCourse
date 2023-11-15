using System;
using UnityEngine;

namespace Task4.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Ball : MonoBehaviour, IBall
    {
        public event Action<Color> OnSelected = delegate { };

        private MeshRenderer _mesh;

        public Color Color => _mesh.material.color;

        private void OnValidate()
        {
            if (_mesh == null) _mesh = GetComponent<MeshRenderer>();
        }

        private void OnMouseUp()
        {
            OnSelected.Invoke(_mesh.material.color);
            gameObject.SetActive(false);
        }

        public void SetColor(Color color)
        {
            _mesh.material.color = color;
        }
    }
}