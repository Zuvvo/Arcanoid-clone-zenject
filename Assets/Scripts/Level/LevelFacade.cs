using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelFacade : MonoBehaviour
    {
        private LevelSpawner _levelSpawner;

        [Inject]
        public void Construct(LevelSpawner levelSpawner)
        {
            _levelSpawner = levelSpawner;
        }

        public void Spawn()
        {
            _levelSpawner.Spawn();
        }
    }
}