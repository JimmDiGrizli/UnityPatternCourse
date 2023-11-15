using System;
using UnityEngine;

namespace Task4.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Ball : MonoBehaviour
    {
        public event Action<Color> OnSelected = delegate { };

        private MeshRenderer _mesh;

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

        public Color Color()
        {
            return _mesh.material.color;
        }
    }
}