using UnityEngine;
using Zenject;

namespace Arkanoid.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle()
                .WithArguments(
                _settings.Rigidbody2D,
                _settings.SpriteRenderer,
                _settings.BoxCollider2D);

            Container.Bind<PlayerSpawner>().AsSingle();
            Container.Bind<PlayerInputState>().AsSingle();

            Container.BindInterfacesTo<PlayerMovement>().AsSingle();
            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
        }
    }

    [System.Serializable]
    public class Settings
    {
        public Rigidbody2D Rigidbody2D;
        public SpriteRenderer SpriteRenderer;
        public BoxCollider2D BoxCollider2D;
    }
}