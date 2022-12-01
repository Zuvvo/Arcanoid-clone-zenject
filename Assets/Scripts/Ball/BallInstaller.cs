using UnityEngine;
using Zenject;

namespace Arkanoid.GameElements
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BallMovement>().AsSingle()
                .WithArguments(
                _settings.Rigidbody,
                _settings.Speed
                );

            Container.BindInstance(_settings).AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public Rigidbody2D Rigidbody;
            public float Speed;
        }
    }
}