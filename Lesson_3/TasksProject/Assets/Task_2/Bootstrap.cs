using System;
using System.Collections.Generic;
using Task_2.Image.HUD;
using Task_2.Image.Store;
using UnityEngine;

namespace Task_2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private List<SectionView> _views;
        [SerializeField] private SectionType _sectionType;

        [ContextMenu("BuildMenu")]
        public void Switch()
        {
            ResourceImageFactory factory = _sectionType switch
            {
                SectionType.Store => new StoreResourceFactory(),
                SectionType.HUD => new HUDResourceFactory(),
                _ => throw new ArgumentOutOfRangeException()
            };

            _views.ForEach(view => view.Render(factory.Get(view.Type)));
        }
    }
}