using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SaveManagerGameScene : MonoBehaviour
    {
        private Storage _storage;
        private GameData _gameData;

        [SerializeField] private Toggle _soundsToggle;
        [SerializeField] private Toggle _musicToggle;

        private void Start()
        {
            _storage = new Storage();
            Load();

            _soundsToggle.onValueChanged.AddListener(OnSwitch);
            _musicToggle.onValueChanged.AddListener(OnSwitch);
        }

        public void Save()
        {
            _gameData.SoundsIsActive = _soundsToggle.isOn;
            _gameData.MusicIsActive = _musicToggle.isOn;            

            _storage.Save(_gameData);
        }

        public void Load()
        {
            _gameData = (GameData)_storage.Load(new GameData());

            _soundsToggle.isOn = _gameData.SoundsIsActive;
            _musicToggle.isOn = _gameData.MusicIsActive;

            if(SecondaryInformation.IsContinuation == true)
            {
                //загрузка сэйва
            }
            else
            {
                switch (_gameData.SelectedDifficulty)
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
                }
            }
        }

        private void OnSwitch(bool on)
        {
            Save();
        }
    }
}
