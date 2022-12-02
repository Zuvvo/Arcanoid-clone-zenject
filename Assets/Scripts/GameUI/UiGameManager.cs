using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Arkanoid.Level;
using TMPro;
using Arkanoid.Save;
using UnityEngine.SceneManagement;
using Arkanoid.Constants;
using System;

namespace Arkanoid.UI
{
    public class UiGameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _uiText;

        [SerializeField] private GameObject _uiPause;
        [SerializeField] private Button _resumeGameButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _quitButton;

        [SerializeField] private GameObject _uiEndGame;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        [SerializeField] private Button _backToMenuButton;

        [Inject] private readonly LevelController _levelController;
        [Inject] private readonly GameSaveManager _gameSaveManager;

        private void Start()
        {
            OnGameStateChanged();
            _backToMenuButton.onClick.AddListener(OnBackToMenuClicked);
            _resumeGameButton.onClick.AddListener(OnResumeGameClicked);
            _saveButton.onClick.AddListener(OnSaveClicked);
            _quitButton.onClick.AddListener(OnQuitClicked);
        }

        private void OnBackToMenuClicked()
        {
            SceneManager.LoadScene(SceneNames.MainMenu);
            Time.timeScale = 1;
        }

        public void OnGameStateChanged()
        {
            _uiText.text = $"Highscore: {_gameSaveManager.HighscoresData.Points}\nPoints: {_levelController.CurrentPoints}\nLives: {_levelController.CurrentLives}";
        }

        public void OnGamePaused(GamePaused gamePaused)
        {
            Time.timeScale = 0;
            _uiPause.SetActive(true);
        }

        public void OnGameLost(GameLost gameLost)
        {
            _uiEndGame.SetActive(true);
            _scoreText.text = $"Score: {gameLost.Score}";
            _highScoreText.text = $"Highscore: {_gameSaveManager.HighscoresData.Points}";
            Time.timeScale = 0;
            _gameSaveManager.TryDestroyCurrentSave();
        }

        private void OnQuitClicked()
        {
            Application.Quit();
        }

        private void OnSaveClicked()
        {
            _levelController.SaveGame();
            _gameSaveManager.SaveCurrentData();
            ClosePauseWindow();
        }

        private void ClosePauseWindow()
        {
            _uiPause.SetActive(false);
            Time.timeScale = 1;
        }

        private void OnResumeGameClicked()
        {
            ClosePauseWindow();
        }
    }
}