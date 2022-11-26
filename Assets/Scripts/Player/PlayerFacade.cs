using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerFacade : MonoBehaviour
    {
        private PlayerSpawner _playerSpawner;

        [Inject]
        public void Construct(PlayerSpawner playerSpawner)
        {
            _playerSpawner = playerSpawner;
        }

        public void Spawn()
        {
            _playerSpawner.Spawn();
        }
    }
}