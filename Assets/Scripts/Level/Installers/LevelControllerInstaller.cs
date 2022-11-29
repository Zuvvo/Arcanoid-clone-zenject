using Zenject;
using Arkanoid.GameElements;

namespace Arkanoid.Level
{
    public class LevelControllerInstaller : MonoInstaller<LevelControllerInstaller>
    {
        [Inject]
        LevelSettingsInstaller.LevelSettings _settings = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
            Container.Bind<LevelSpawner>().AsSingle();

            Container.BindFactory<BallFacade, BallFacade.Factory>()
                .FromPoolableMemoryPool<BallFacade, BallFacadePool>(poolBinder => poolBinder
                .WithInitialSize(5)
                .FromSubContainerResolve()
                .ByNewContextPrefab(_settings.BallPrefab)
                .UnderTransformGroup("Balls"));

            Container.BindFactory<BrickFacade, BrickFacade.Factory>()
                .FromPoolableMemoryPool<BrickFacade, BrickFacadePool>(poolBinder => poolBinder
                .WithInitialSize(150)
                .FromSubContainerResolve()
                .ByNewContextPrefab(_settings.BrickPrefab)
                .UnderTransformGroup("Bricks"));

            GameSignalsInstaller.Install(Container);
            Container.BindSignal<BallEscapedSignal>().ToMethod<LevelController>(x => x.OnBallEscaped).FromResolve();
        }

        class BallFacadePool : MonoPoolableMemoryPool<IMemoryPool, BallFacade>
        {
        }

        class BrickFacadePool : MonoPoolableMemoryPool<IMemoryPool, BrickFacade>
        {
        }
    }
}