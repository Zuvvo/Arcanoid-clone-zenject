using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelPrefabInstaller : MonoInstaller
    {

        [Inject] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            InstallLevel();
        }

        private void InstallLevel()
        {
            Debug.Log("install level");
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