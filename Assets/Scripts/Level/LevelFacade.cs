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
            BoxCollider2D leftWall = walls.OrderBy(x => x.transform.position.x).First();
            return leftWall.transform.position.x + leftWall.bounds.size.x / 2;
        }
        
        public float GetXMaxWallBorders()
        {
            List<BoxCollider2D> walls = Walls.ToList();
            BoxCollider2D rightWall = walls.OrderBy(x => x.transform.position.x).Last();
            return rightWall.transform.position.x - rightWall.bounds.size.x / 2;
        }

        public float GetYMaxWallBorders()
        {
            List<BoxCollider2D> walls = Walls.ToList();
            BoxCollider2D topWall = walls.OrderBy(x => x.transform.position.y).Last();
            return topWall.transform.position.y - topWall.bounds.size.y / 2;
        }
    }
}