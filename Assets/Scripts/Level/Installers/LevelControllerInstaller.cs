using UnityEngine;
using Zenject;
using Arkanoid.GameElements;

namespace Level
{
    public class LevelControllerInstaller : MonoInstaller<LevelControllerInstaller>
    {
        [Inject]
        LevelSettingsInstaller.LevelSettings _settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
            Container.Bind<LevelSpawner>().AsSingle();

            Container.BindFactory<Ball, Ball.Factory>()
                .FromPoolableMemoryPool<Ball, BallPool>(poolBinder => poolBinder
                .WithInitialSize(5)
                .FromComponentInNewPrefab(_settings.BallPrefab)
                .UnderTransformGroup("Balls"));
        }

        class BallPool : MonoPoolableMemoryPool<IMemoryPool, Ball>
        {
        }
    }
}