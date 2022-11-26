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
        private readonly LevelFacade _levelFacade;

        public LevelController(PlayerFacade playerFacade, LevelFacade levelFacade)
        {
            _playerFacade = playerFacade;
            _levelFacade = levelFacade;
        }

        public void Initialize()
        {
            _levelFacade.Spawn();
            _playerFacade.Spawn();
            Cursor.visible = false;
        }

        public void Tick()
        {

        }
    }
}
