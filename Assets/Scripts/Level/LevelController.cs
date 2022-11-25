using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Player;

namespace Level
{
    public class LevelController : ITickable, IInitializable
    {
        private readonly PlayerFacade _playerFacade;

        public LevelController(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        public void Initialize()
        {
            _playerFacade.Spawn();
        }

        public void Tick()
        {

        }
    }
}
