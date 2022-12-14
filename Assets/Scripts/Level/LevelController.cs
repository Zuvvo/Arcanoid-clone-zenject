using System.Collections.Generic;
using Zenject;
using Arkanoid.Player;
using Arkanoid.GameElements;
using Arkanoid.Save;
using UnityEngine;
using System;

namespace Arkanoid.Level
{
    public class LevelController : IInitializable, ITickable
    {
        public int CurrentPoints { get; private set; }
        public int CurrentLives { get; private set; }
        public int CurrentLevel { get; private set; }

        private readonly PlayerFacade _playerFacade;
        private readonly LevelFacade _levelFacade;
        private readonly BallFacade.Factory _ballsFactory;
        private readonly BrickFacade.Factory _bricksFactory;
        private readonly LevelSettingsInstaller.LevelSettings _settings;

        [Inject] private readonly GameSaveManager _gameSaveManager;
        [Inject] private readonly SignalBus _signalBus;

        private List<BallFacade> _currentBalls = new List<BallFacade>();
        private Dictionary<int, BrickFacade> _currentBricks = new Dictionary<int, BrickFacade>();

        #region Initializers
        public LevelController(PlayerFacade playerFacade,
            LevelFacade levelFacade,
            BallFacade.Factory ballsFactory,
            BrickFacade.Factory bricksFactory,
            LevelSettingsInstaller.LevelSettings settings)
        {
            _playerFacade = playerFacade;
            _levelFacade = levelFacade;
            _ballsFactory = ballsFactory;
            _bricksFactory = bricksFactory;
            _settings = settings;
        }

        public void Initialize()
        {
            SetGameSateData();
            _levelFacade.Spawn();
            _playerFacade.Spawn();
            SpawnBalls();
            SpawnBricks();
        }

        private void SetGameSateData()
        {
            CurrentLevel = _gameSaveManager.GameShouldBeLoaded ? _gameSaveManager.GameSaveData.CurrentLevel : 1;
            CurrentLives = _gameSaveManager.GameShouldBeLoaded ? _gameSaveManager.GameSaveData.CurrentLives : 3;
            CurrentPoints = _gameSaveManager.GameShouldBeLoaded ? _gameSaveManager.GameSaveData.CurrentPoints : 0;
        }
        #endregion

        #region Save

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _signalBus.Fire(new GamePaused());
            }
        }

        public void SaveGame()
        {
            SaveBalls();
            SaveLevel();
            SavePoints();
            _gameSaveManager.SaveCurrentData();
        }

        private void SavePoints()
        {
            _gameSaveManager.UpdateCurrentLevelData(CurrentLevel);
        }

        private void SaveLevel()
        {
            _gameSaveManager.UpdateCurrentLevelData(CurrentLevel);
        }

        public void SaveBalls()
        {
            List<BallData> ballsData = new List<BallData>();
            for (int i = 0; i < _currentBalls.Count; i++)
            {
                ballsData.Add(_currentBalls[i].GetSaveDataContainer() as BallData);
            }
            _gameSaveManager.UpdateBallsData(ballsData);
        }
        #endregion

        #region Balls

        public void OnBallEscaped(BallEscapedSignal ballEscapedSignal)
        {
            ballEscapedSignal.BallRef.Dispose();
            _currentBalls.Remove(ballEscapedSignal.BallRef);
            SpawnBalls();
            CurrentLives--;
            CallOnGameStateChanged();

            if(CurrentLives <= 0)
            {
                LoseGame();
            }
        }

        private void SpawnBalls()
        {
            if (_gameSaveManager.GameShouldBeLoaded)
            {
                for (int i = 0; i < _gameSaveManager.GameSaveData.BallsData.Count; i++)
                {
                    BallData data = _gameSaveManager.GameSaveData.BallsData[i];
                    var ball = _ballsFactory.Create();
                    ball.UpdateObjectFromSaveData(data);
                    _currentBalls.Add(ball);
                }
            }
            else
            {
                var ball = _ballsFactory.Create();
                float xPos = UnityEngine.Random.Range(_levelFacade.GetXMinWallBorders(), _levelFacade.GetXMaxWallBorders());
                ball.transform.position = new Vector3(xPos, 0, 0);
                _currentBalls.Add(ball);
            }
        }
        #endregion

        #region Bricks

        public void OnBrickDestroyed(BrickDestroyedSignal brickDestroyedSignal)
        {
            BrickFacade brick = _currentBricks[brickDestroyedSignal.Id];
            brick.Dispose();
            _currentBricks.Remove(brickDestroyedSignal.Id);
            CurrentPoints++;
            CallOnGameStateChanged();
        }

        private void SpawnBricks()
        {
            BrickFacade brick = _bricksFactory.Create();
            BoxCollider2D brickCollider = brick.Settings.BoxCollider;

            float brickHeight = brickCollider.bounds.size.y;
            float brickLength = brickCollider.bounds.size.x;

            float minX = _levelFacade.GetXMinWallBorders();
            float maxX = _levelFacade.GetXMaxWallBorders();
            float maxY = _levelFacade.GetYMaxWallBorders();

            brick.Dispose();

            int row = 0;
            int column = 0;
            int idCounter = 0;

            for (int i = 0; i < _settings.BricksCount; i++)
            {
                brick = _bricksFactory.Create();
                brick.Id = idCounter;
                _currentBricks.Add(brick.Id, brick);

                float startXPos = minX + _settings.LeftOffsetForBricks + (brickLength / 2);
                float posX = startXPos;
                posX += column * (brickLength + _settings.SpaceXBetweenBricks);
                column += 1;
                if (posX + brickLength / 2 + _settings.RightOffsetForBricks > maxX)
                {
                    posX = startXPos;
                    row += 1;
                    column = 1;
                }

                float posY = maxY - _settings.TopOffsetForBricks - brickHeight / 2 - (row * (brickHeight + _settings.SpaceYBetweenBricks));

                brick.transform.position = new Vector3(posX, posY, 0);

                idCounter++;
            }
        }

        #endregion

        #region GameState

        private void LoseGame()
        {
            _gameSaveManager.SaveHighscores(new HighscoreSaveData() { Points = CurrentPoints });
            _signalBus.Fire(new GameLost() { Score = CurrentPoints });
        }

        private void WinGame()
        {

        }

        private void CallOnGameStateChanged()
        {
            _signalBus.Fire(new GameStateChanged());
        }

        #endregion
    }
}