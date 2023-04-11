using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Multipliers
{
    public class SaveManagerGameScene : MonoBehaviour
    {
        private Storage _storage;
        [HideInInspector] public GameData GameData;

        [Header("Toggles")]
        [SerializeField] private Toggle _soundsToggle;
        [SerializeField] private Toggle _musicToggle;

        [Header("Scripts")]
        [SerializeField] private Timer _timer;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private NewInLine _newInLine;

        [Header("Panels")]
        [SerializeField] private GameObject _firstPanel;
        [SerializeField] private GameObject _secondPanel;
        [SerializeField] private GameObject _thirdPanel;
        [SerializeField] private GameObject _reservePanel;

        private void Awake()
        {
            _storage = new Storage();
            Load();
        }

        public void Save()
        {
            GameData.SoundsIsActive = _soundsToggle.isOn;
            GameData.MusicIsActive = _musicToggle.isOn;

            GameData.TimeOnTimer = _timer.TimeOnTimer;
            GameData.DifficultyIndex = _levelGenerator.DifficultyIndex;

            GameData.FirstPanelMultipliers = _levelGenerator.FirstPanelMultipliers;
            GameData.SecondPanelMultipliers = _levelGenerator.SecondPanelMultipliers;
            GameData.ThirdPanelMultipliers = _levelGenerator.ThirdPanelMultipliers;
            GameData.ReserveMultipliers = _levelGenerator.ReserveMultipliers;

            for(int i = 0; i < 6; i++)
            {
                GameData.FirstPlaneMultipliers[i] = _firstPanel.transform.GetChild(i).gameObject.
                    GetComponent<TextMeshProUGUI>().text;
                GameData.SecondPlaneMultipliers[i] = _secondPanel.transform.GetChild(i).gameObject.
                    GetComponent<TextMeshProUGUI>().text;
                GameData.ThirdPlaneMultipliers[i] = _thirdPanel.transform.GetChild(i).gameObject.
                    GetComponent<TextMeshProUGUI>().text;
            }

            for(int i = 0; i < 10; i++)
            {
                GameData.ReservePlaneMultipliers[i] = _reservePanel.transform.GetChild(i).gameObject.
                    GetComponent<TextMeshProUGUI>().text;
            }

            for (int i = 0; i < 5; i++)
            {
                GameData.FirstPlaneMultiplication[i] = _firstPanel.transform.GetChild(i + 6).gameObject.
                    activeInHierarchy;
                GameData.SecondPlaneMultiplication[i] = _secondPanel.transform.GetChild(i + 6).gameObject.
                    activeInHierarchy;
                GameData.ThirdPlaneMultiplication[i] = _thirdPanel.transform.GetChild(i + 6).gameObject.
                    activeInHierarchy;
            }

            GameData.FirstPlaneCompositionRight = _firstPanel.transform.GetChild(11).
                GetComponent<TextMeshProUGUI>().text;
            GameData.SecondPlaneCompositionRight = _secondPanel.transform.GetChild(11).
                GetComponent<TextMeshProUGUI>().text;
            GameData.ThirdPlaneCompositionRight = _secondPanel.transform.GetChild(11).
                GetComponent<TextMeshProUGUI>().text;

            _storage.Save(GameData);
        }

        public void Load()
        {
            GameData = (GameData)_storage.Load(new GameData());

            if (SecondaryInformation.IsContinuation)
            {
                _timer.TimeOnTimer = GameData.TimeOnTimer;
                _levelGenerator.DifficultyIndex = GameData.DifficultyIndex;

                _levelGenerator.FirstPanelMultipliers = GameData.FirstPanelMultipliers;
                _levelGenerator.SecondPanelMultipliers = GameData.SecondPanelMultipliers;
                _levelGenerator.ThirdPanelMultipliers = GameData.ThirdPanelMultipliers;
                _levelGenerator.ReserveMultipliers = GameData.ReserveMultipliers;

                for (int i = 0; i < 6; i++)
                {
                    _firstPanel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText(GameData.FirstPlaneMultipliers[i]);
                    _secondPanel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText(GameData.SecondPlaneMultipliers[i]);
                    _thirdPanel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText(GameData.ThirdPlaneMultipliers[i]);
                }

                for (int i = 0; i < 10; i++)
                {
                    _reservePanel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText(GameData.ReservePlaneMultipliers[i]);
                }

                for (int i = 0; i < 5; i++)
                {
                    _firstPanel.transform.GetChild(i + 6).gameObject.SetActive(GameData.FirstPlaneMultiplication[i]);
                    _secondPanel.transform.GetChild(i + 6).gameObject.SetActive(GameData.SecondPlaneMultiplication[i]);
                    _thirdPanel.transform.GetChild(i + 6).gameObject.SetActive(GameData.ThirdPlaneMultiplication[i]);
                }

                _firstPanel.transform.GetChild(11).GetComponent<TextMeshProUGUI>().
                    SetText(GameData.FirstPlaneCompositionRight);
                _secondPanel.transform.GetChild(11).GetComponent<TextMeshProUGUI>().
                    SetText(GameData.SecondPlaneCompositionRight);
                _secondPanel.transform.GetChild(11).GetComponent<TextMeshProUGUI>().
                    SetText(GameData.ThirdPlaneCompositionRight);
            }

            _soundsToggle.isOn = GameData.SoundsIsActive;
            _musicToggle.isOn = GameData.MusicIsActive;
        }
    }
}