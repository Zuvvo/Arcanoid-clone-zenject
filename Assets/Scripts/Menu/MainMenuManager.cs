using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using Arkanoid.Constants;

namespace Arkanoid.Menu
{
    public class MainMenuManager
    {
        public void ContinueGame()
        {
            Debug.Log("continue game");
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneNames.Game);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}