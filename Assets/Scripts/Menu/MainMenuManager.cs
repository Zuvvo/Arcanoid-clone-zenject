using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Arkanoid.Constants;
using Arkanoid.Save;

namespace Arkanoid.Menu
{
    public class MainMenuManager
    {
        [Inject] private readonly GameSaveManager _gameSaveManager;
        public void ContinueGame()
        {
            if (_gameSaveManager.LoadDataFromFile())
            {
                _gameSaveManager.GameShouldBeLoaded = true;
                SceneManager.LoadScene(SceneNames.Game);
            }
            else
            {
                Debug.LogError("Game can't be loaded");
            }
        }

        public void StartGame()
        {
            _gameSaveManager.GameShouldBeLoaded = false;
            SceneManager.LoadScene(SceneNames.Game);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}