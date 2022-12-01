using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Arkanoid.Level;
using TMPro;
using Arkanoid.Save;

namespace Arkanoid.UI
{
    public class UiGameManager : MonoBehaviour
    {
        [Inject] private readonly LevelController _levelController;
        [Inject] private readonly GameSaveManager _gameSaveManager;
        [SerializeField] private TextMeshProUGUI _uiText;


        private void Start()
        {
            OnGameStateChanged();
        }

        public void OnGameStateChanged()
        {
            _uiText.text = $"Highscore: {_gameSaveManager.HighscoresData.Points}\nPoints: {_levelController.CurrentPoints}\nLives: {_levelController.CurrentLives}";
        }
    }
}