using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SaveManagerGameScene : MonoBehaviour
    {
        private Storage _storage;
        [HideInInspector] public GameData GameData;

        [SerializeField] private Toggle _soundsToggle;
        [SerializeField] private Toggle _musicToggle;

        private void Awake()
        {
            _storage = new Storage();
            Load();
        }

        public void Save()
        {
            GameData.SoundsIsActive = _soundsToggle.isOn;
            GameData.MusicIsActive = _musicToggle.isOn;

            _storage.Save(GameData);
        }

        public void Load()
        {
            GameData = (GameData)_storage.Load(new GameData());

            _soundsToggle.isOn = GameData.SoundsIsActive;
            _musicToggle.isOn = GameData.MusicIsActive;
        }
    }
}