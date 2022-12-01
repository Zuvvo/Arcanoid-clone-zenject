using Arkanoid.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkanoid.Menu
{
    public class UiMainMenu : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;

        [Inject] private readonly MainMenuManager _mainMenuManager;
        [Inject] private readonly GameSaveManager _gameSaveManager;

        private void Start()
        {
            _continueButton.onClick.AddListener(_mainMenuManager.ContinueGame);
            _continueButton.interactable = _gameSaveManager.DoesSaveFileExists();

            _startButton.onClick.AddListener(_mainMenuManager.StartGame);
            _exitButton.onClick.AddListener(_mainMenuManager.ExitGame);
        }
    }
}