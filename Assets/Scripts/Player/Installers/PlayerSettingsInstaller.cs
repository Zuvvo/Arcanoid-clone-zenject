using System;
using UnityEngine;
using Zenject;

namespace Arkanoid.Player
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
    public class PlayerSettingsInstaller : ScriptableObjectInstaller<PlayerSettingsInstaller>
    {
        public PlayerSettings Player;
        public PlayerPrefabInstaller.Settings PlayerPrefabInstaller;

        public override void InstallBindings()
        {
            Container.BindInstance(PlayerPrefabInstaller).IfNotBound();
            Container.BindInstance(Player.Movement);
        }

        [Serializable]
        public class PlayerSettings
        {
            public PlayerMovement.Settings Movement;
        }
    }
}