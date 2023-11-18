using System;
using UnityEngine;

namespace Task4.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Ball : MonoBehaviour, IBall
    {
        public event Action<ColorScriptableObject> OnSelected = delegate { };

        private MeshRenderer _mesh;

        public ColorScriptableObject Color { get; private set; }

        private void OnValidate()
        {
            if (_mesh == null) _mesh = GetComponent<MeshRenderer>();
        }

        public void Prepare(ColorScriptableObject color)
        {
            Color = color;
            _mesh.material.color = color.Color;
            gameObject.SetActive(true);
        }

        public void Select()
        {
            OnSelected.Invoke(Color);
            Deactivate();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}