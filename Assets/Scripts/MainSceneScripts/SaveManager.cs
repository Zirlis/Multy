using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SaveManager : MonoBehaviour
    {
        private Storage _storage;
        [HideInInspector] public GameData GameData;

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
            GameData.SoundsIsActive = _soundsToggle.isOn;
            GameData.MusicIsActive = _musicToggle.isOn;

            if (_hardScore.text != "" && Int32.Parse(_hardScore.text) > 0)               
                GameData.HardScore = Int32.Parse(_hardScore.text);                
            
            if (_mediumScore.text != "" && Int32.Parse(_mediumScore.text) > 0)               
                GameData.MediumScore = Int32.Parse(_mediumScore.text);                
            
            if (_easyScore.text != "" && Int32.Parse(_easyScore.text) > 0)
                GameData.EasyScore = Int32.Parse(_easyScore.text);

            if (_lastGameScore.text != "")            
                GameData.LastGameScore = Int32.Parse(_lastGameScore.text);            

            _storage.Save(GameData);
        }

        public void Load()
        {            
            GameData = (GameData)_storage.Load(new GameData());

            _soundsToggle.gameObject.GetComponent<SoundsToggleInMenuScene>().OnSwitch(GameData.SoundsIsActive, true);
            _musicToggle.gameObject.GetComponent<MusicToggleInMenuScene>().OnSwitch(GameData.MusicIsActive, true);

            if (GameData.HardScore > 0)            
                _hardScore.SetText($"{GameData.HardScore}"); 
            
            if (GameData.MediumScore > 0)            
                _mediumScore.SetText($"{GameData.MediumScore}");
            
            if (GameData.EasyScore > 0)            
                _easyScore.SetText($"{GameData.EasyScore}");

            if (GameData.SelectedDifficulty == 0)
                _lastGameImage.SetActive(false);
            else
            {
                _lastGameScore.SetText($"{GameData.LastGameScore}");
                _resumeButton.SetActive(!GameData.GameIsOver);
            }
        }
    }
}