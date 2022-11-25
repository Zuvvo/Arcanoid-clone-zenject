using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Settings _settings;

        public override void InstallBindings()
        {
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
    }

}