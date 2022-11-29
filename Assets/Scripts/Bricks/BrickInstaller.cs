using UnityEngine;
using Zenject;

namespace Arkanoid.GameElements
{
    public class BrickInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
            Container.BindInstance(_settings);
        }

        [System.Serializable]
        public class Settings
        {
            public int Health;
            public BoxCollider2D BoxCollider;
        }
    }
}