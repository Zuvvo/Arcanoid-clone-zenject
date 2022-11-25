using Zenject;

namespace Level
{
    public class LevelControllerInstaller : MonoInstaller<LevelControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelController>().AsSingle();
        }
    }
}