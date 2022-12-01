using UnityEngine;
using Zenject;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;

namespace Arkanoid.Save
{
    public class GameSaveManager : IInitializable
    {
        private const string DIRECTORY_NAME = "Saves";
        private const string SAVE_EXTENSION = "save";
        private const string SAVE_FILE_NAME = "single";
        private const string HIGHSCORE_FILE_NAME = "highscores";

        public bool GameShouldBeLoaded { get; set; }

        public GameSaveData GameSaveData { get; private set; }
        public HighscoreSaveData HighscoresData { get; private set; }
        public void Initialize()
        {
            GameSaveData = new GameSaveData();
            GameSaveData.LevelsData = new List<LevelData>();

            LoadHighscoresData();

            //temp
            GameSaveData.LevelsData.Add(new LevelData());
            GameSaveData.LevelsData.Add(new LevelData());
            GameSaveData.LevelsData.Add(new LevelData());
        }

        public void UpdateCurrentLevelData(int level)
        {
            GameSaveData.CurrentLevel = level;
        }

        public void UpdateBallsData(List<BallData> ballsData)
        {
            GameSaveData.BallsData = ballsData;
        }

        public bool LoadDataFromFile()
        {
            try
            {
                string saveDirectoryFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, DIRECTORY_NAME));
                string fullPath = Path.Combine(saveDirectoryFullPath, $"{SAVE_FILE_NAME}.{SAVE_EXTENSION}");

                if (!File.Exists(fullPath))
                {
                    Debug.LogError($"File missing: {fullPath}");
                    return false;
                }

                XmlSerializer serializer = new XmlSerializer(typeof(GameSaveData));
                StreamReader reader = new StreamReader(fullPath);
                GameSaveData = (GameSaveData)serializer.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
                return false;
            }
        }

        public void LoadHighscoresData()
        {
            HighscoresData = new HighscoreSaveData();

            try
            {
                string saveDirectoryFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, DIRECTORY_NAME));
                string fullPath = Path.Combine(saveDirectoryFullPath, $"{HIGHSCORE_FILE_NAME}.{SAVE_EXTENSION}");

                if (!File.Exists(fullPath))
                {
                    SaveHighscoresToFile();
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(HighscoreSaveData));
                    StreamReader reader = new StreamReader(fullPath);
                    HighscoresData = (HighscoreSaveData)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
        }

        public void SaveHighscores(HighscoreSaveData data)
        {
            HighscoresData = data;
            SaveHighscoresToFile();
        }

        private void SaveHighscoresToFile()
        {
            string saveDirectoryFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, DIRECTORY_NAME));

            if (!Directory.Exists(saveDirectoryFullPath))
            {
                Directory.CreateDirectory(saveDirectoryFullPath);
            }

            XmlSerializer xs = new XmlSerializer(typeof(GameSaveData));
            TextWriter tw = new StreamWriter(Path.Combine(saveDirectoryFullPath, $"{HIGHSCORE_FILE_NAME}.{SAVE_EXTENSION}"));
            xs.Serialize(tw, GameSaveData);
            tw.Close();
        }

        public void SaveCurrentData()
        {
            string saveDirectoryFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, DIRECTORY_NAME));

            if (!Directory.Exists(saveDirectoryFullPath))
            {
                Directory.CreateDirectory(saveDirectoryFullPath);
            }

            XmlSerializer xs = new XmlSerializer(typeof(GameSaveData));
            TextWriter tw = new StreamWriter(Path.Combine(saveDirectoryFullPath, $"{SAVE_FILE_NAME}.{SAVE_EXTENSION}"));
            xs.Serialize(tw, GameSaveData);
            tw.Close();
        }

        public bool DoesSaveFileExists()
        {
            string saveDirectoryFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, DIRECTORY_NAME));
            string savePath = Path.GetFullPath(Path.Combine(saveDirectoryFullPath, string.Format("{0}.{1}", SAVE_FILE_NAME, SAVE_EXTENSION)));
            return File.Exists(savePath);
        }
    }
}