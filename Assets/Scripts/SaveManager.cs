using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SaveManager : MonoBehaviour
    {
        private Storage _storage;
        private GameData _gameData;

        [SerializeField] private Toggle _soundsToggle;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private TextMeshProUGUI _hardScore;
        [SerializeField] private TextMeshProUGUI _mediumScore;
        [SerializeField] private TextMeshProUGUI _easyScore;
        [SerializeField] private TextMeshProUGUI _lastGameScore;
        [SerializeField] private GameObject _lastGameImage;
        [SerializeField] private GameObject _resumeButton;        

        private void Awake()
        {
            _storage = new Storage();
            Load();
        }

        public void Save()
        {
            _gameData.SoundsIsActive = _soundsToggle.isOn;
            _gameData.MusicIsActive = _musicToggle.isOn;

            if (_hardScore.text != "")
            {
                if (Int32.Parse(_hardScore.text) > 0)
                {
                    _gameData.HardScore = Int32.Parse(_hardScore.text);
                }
            }
            if (_mediumScore.text != "")
            {
                if (Int32.Parse(_mediumScore.text) > 0)
                {
                    _gameData.MediumScore = Int32.Parse(_mediumScore.text);
                }
            }
            if (_easyScore.text != "")
            {
                if (Int32.Parse(_easyScore.text) > 0)
                {
                    _gameData.EasyScore = Int32.Parse(_easyScore.text);
                }
            }

            if (_lastGameScore.text != "")
            {
                _gameData.LastGameScore = Int32.Parse(_lastGameScore.text);
            }

            _storage.Save(_gameData);
        }

        public void Load()
        {
            _gameData = (GameData)_storage.Load(new GameData());

            _soundsToggle.isOn = _gameData.SoundsIsActive;
            _musicToggle.isOn = _gameData.MusicIsActive;

            if (_gameData.HardScore > 0)
            {
                _hardScore.text = $"{_gameData.HardScore}";
            }
            if (_gameData.MediumScore > 0)
            {
                _mediumScore.text = $"{_gameData.MediumScore}";
            }
            if (_gameData.EasyScore > 0)
            {
                _easyScore.text = $"{_gameData.EasyScore}";
            }

            _lastGameScore.text = $"{_gameData.LastGameScore}";
            SetLastGame(_gameData.SelectedDifficulty);

            if(_gameData.GameIsOver == false)
            {
                _resumeButton.SetActive(true);
            }
        }

        private void SetLastGame(int lastGameDifficulty)
        {
            switch (lastGameDifficulty)
            {
                case 3:
                    //hard
                    break;
                case 2:
                    //medium
                    break;
                case 1:
                    //easy
                    break;
                default:
                    _lastGameImage.SetActive(false);
                    break;
            }
        }
    }
}