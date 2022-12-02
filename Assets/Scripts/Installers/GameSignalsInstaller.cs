using Zenject;

namespace Arkanoid
{
    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<BallEscapedSignal>();
            Container.DeclareSignal<BrickDestroyedSignal>();
            Container.DeclareSignal<GameStateChanged>();
            Container.DeclareSignal<GameLost>();
            Container.DeclareSignal<GamePaused>();
        }
    }
}