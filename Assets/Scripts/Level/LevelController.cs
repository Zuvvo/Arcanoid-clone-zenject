using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Player;
using System;
using Arkanoid.GameElements;

namespace Level
{
    public class LevelController : ITickable, IInitializable
    {
        private readonly PlayerFacade _playerFacade;
        private readonly LevelFacade _levelFacade;
        private readonly Ball.Factory _ballsFactory;

        private List<Ball> _currentBalls = new List<Ball>();

        public LevelController(PlayerFacade playerFacade, LevelFacade levelFacade, Ball.Factory ballsFactory)
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

        private void SpawnBall()
        {
            var ball = _ballsFactory.Create();
            _currentBalls.Add(ball);
        }

        public void Tick()
        {

        }
    }
}
