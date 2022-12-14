using UnityEngine;
using Zenject;

namespace Arkanoid.Level
{
    public class LevelPrefabInstaller : MonoInstaller
    {

        [Inject] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            Container.Bind<LevelFacade>()
                .FromComponentInNewPrefab(_settings.LevelPrefab)
                .UnderTransformGroup("Level")
                .AsSingle();


        }

        [System.Serializable]
        public class Settings
        {
            public GameObject LevelPrefab;
        }
    }

}