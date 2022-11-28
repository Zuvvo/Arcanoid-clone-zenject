using System.Collections.Generic;
using Zenject;
using Arkanoid.Player;
using Arkanoid.GameElements;
using UnityEngine;

namespace Arkanoid.Level
{
    public class LevelController : ITickable, IInitializable
    {
        private readonly PlayerFacade _playerFacade;
        private readonly LevelFacade _levelFacade;
        private readonly BallFacade.Factory _ballsFactory;

        private List<BallFacade> _currentBalls = new List<BallFacade>();

        public LevelController(PlayerFacade playerFacade, LevelFacade levelFacade, BallFacade.Factory ballsFactory)
        {
            _playerFacade = playerFacade;
            _levelFacade = levelFacade;
            _ballsFactory = ballsFactory;
        }

        public void Initialize()
        {
            _levelFacade.Spawn();
            _playerFacade.Spawn();
            SpawnBall();
        }

        public void OnBallEscaped()
        {
            foreach (var ball in _currentBalls) //todo get ref of destroyed ball
            {
                ball.Dispose();
            }
            _currentBalls.Clear();

            SpawnBall();
        }

        private void SpawnBall()
        {
            var ball = _ballsFactory.Create();
            float xPos = Random.Range(_levelFacade.GetXMinWallBorders(), _levelFacade.GetXMaxWallBorders());
            ball.transform.position = new Vector3(xPos, 0, 0);
            _currentBalls.Add(ball);
        }

        public void Tick()
        {

        }
    }
}
