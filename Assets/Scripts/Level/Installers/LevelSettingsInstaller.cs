using System;
using UnityEngine;
using Zenject;

namespace Arkanoid.Level
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Scriptable Objects/LevelSettings")]
    public class LevelSettingsInstaller : ScriptableObjectInstaller<LevelSettingsInstaller>
    {
        public LevelSettings Level;
        public LevelPrefabInstaller.Settings LevelPrefabInstaller;

        public override void InstallBindings()
        {
            Container.BindInstance(Level).IfNotBound();
            Container.BindInstance(LevelPrefabInstaller).IfNotBound();
        }

        [Serializable]
        public class LevelSettings
        {
            public float BricksCount;
            public float SpaceXBetweenBricks;
            public float SpaceYBetweenBricks;
            public float LeftOffsetForBricks;
            public float RightOffsetForBricks;
            public float TopOffsetForBricks;
            public GameObject BallPrefab;
            public GameObject BrickPrefab;
        }
    }
}