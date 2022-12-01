using UnityEngine;
using Zenject;

namespace Arkanoid.UI
{
    public class UiGameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _uiHolder;
        public override void InstallBindings()
        {
            Container.Bind<UiGameManager>().FromComponentOn(_uiHolder).AsSingle();

            Container.BindSignal<GameStateChanged>().ToMethod<UiGameManager>(x => x.OnGameStateChanged).FromResolve();
        }
    }
}