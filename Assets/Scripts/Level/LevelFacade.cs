using System.Collections.Generic;
using System.Linq;
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

        public float GetXMinWallBorders()
        {
            List<BoxCollider2D> walls = Walls.ToList();
            return walls.Min(x => x.transform.position.x);
        }
        
        public float GetXMaxWallBorders()
        {
            List<BoxCollider2D> walls = Walls.ToList();
            return walls.Max(x => x.transform.position.x);
        }
    }
}