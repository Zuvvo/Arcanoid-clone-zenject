using UnityEngine;
using Zenject;

namespace Arkanoid.Level
{
    public class LevelFacade : MonoBehaviour
    {
        public BoxCollider2D[] Walls;
        public ObjectsDestroyer ObjectsDestroyer;
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