using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Save
{
    [System.Serializable]
    public class GameSaveData
    {
        public int Highscore;
        public int CurrentLevel;
        public List<LevelData> LevelsData;
        public List<BallData> BallsData;
    }

    [System.Serializable]
    public class BallData
    {
        public float BallPositionX;
        public float BallPositionY;
        public float BallMoveVectorX;
        public float BallMoveVectorY;
    }

    [System.Serializable]
    public class LevelData
    {
        public List<BrickData> BricksData;
    }


    [System.Serializable]
    public class BrickData
    {
        public int Id;
        public bool IsDestroyed;
    }
}