using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Save
{
    [System.Serializable]
    public class GameSaveData : ISaveDataContainer
    {
        public GameSaveData() { }

        public int CurrentPoints;
        public int CurrentLevel;
        public List<LevelData> LevelsData;
        public List<BallData> BallsData;
    }

    [System.Serializable]
    public class HighscoreSaveData : ISaveDataContainer
    {
        public HighscoreSaveData() { }

        public int Points;
    }

    [System.Serializable]
    public class BallData : ISaveDataContainer
    {
        public BallData() { }

        public float BallPositionX;
        public float BallPositionY;
        public float BallMoveVectorX;
        public float BallMoveVectorY;
    }

    [System.Serializable]
    public class LevelData : ISaveDataContainer
    {
        public LevelData() { }

        public List<BrickData> BricksData;
    }


    [System.Serializable]
    public class BrickData : ISaveDataContainer
    {
        public BrickData() { }

        public int Id;
        public bool IsDestroyed;
    }
}