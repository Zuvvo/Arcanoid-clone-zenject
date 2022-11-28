using UnityEngine;
using Zenject;

namespace Arkanoid.Player
{
    public class PlayerPrefabInstaller : MonoInstaller
    {
        [Inject] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            InstallPlayer();
        }

        private void InstallPlayer()
        {
            Container.Bind<PlayerFacade>()
                .FromComponentInNewPrefab(_settings.PlayerPrefab)
                .UnderTransformGroup("Player")
                .AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public GameObject PlayerPrefab;
        }
    }
}