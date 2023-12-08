using System;
using Task_3.Scripts.Level;
using UnityEngine;
using Zenject;

namespace Task_3.Scripts.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraSizeController : MonoBehaviour
    {
        private UnityEngine.Camera _camera;

        [Inject]
        private void Construct(LevelData data)
        {
            _camera.orthographicSize = Math.Max(data.Width, data.Height) + 1;
        }

        public void OnValidate() => _camera ??= GetComponent<UnityEngine.Camera>();
    }
}