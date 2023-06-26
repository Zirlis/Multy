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

        private void Start()
        {
            _storage = new Storage();
            Load();
        }

        public void Save()
        {
            GameData.SoundsIsActive = _soundsToggle.isOn;
            GameData.MusicIsActive = _musicToggle.isOn;

            GameData.TimeOnTimer = _timer.TimeOnTimer;

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
            GameData.ThirdPlaneCompositionRight = _thirdPanel.transform.GetChild(11).
                GetComponent<TextMeshProUGUI>().text;

            _storage.Save(GameData);
        }

        public void Load()
        {
            GameData = (GameData)_storage.Load(new GameData());

            _soundsToggle.GetComponent<SoundsToggleInGameScene>().SetIsOn(GameData.SoundsIsActive);
            _musicToggle.GetComponent<MusicToggleInGameScene>().SetIsOn(GameData.MusicIsActive);

            if (SecondaryInformation.IsContinuation)
            {
                _timer.TimeOnTimer = GameData.TimeOnTimer + 1;
                _timer.SetTimeOnTimer();

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
                _thirdPanel.transform.GetChild(11).GetComponent<TextMeshProUGUI>().
                    SetText(GameData.ThirdPlaneCompositionRight);

                _newInLine.Recalculation(_firstPanel);
                _newInLine.Recalculation(_secondPanel);
                _newInLine.Recalculation(_thirdPanel);

                if (_firstPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text ==
                    _firstPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text)
                {
                    _firstPanel.GetComponent<Animator>().Play($"Connected" +
                        $"{_firstPanel.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _firstPanel.GetComponent<PanelChangeImage>().IsConnecteed = true;
                }

                if (_secondPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text ==
                    _secondPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text)
                {
                    _secondPanel.GetComponent<Animator>().Play($"Connected" +
                        $"{_secondPanel.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _secondPanel.GetComponent<PanelChangeImage>().IsConnecteed = true;
                }

                if (_thirdPanel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text ==
                    _thirdPanel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text)
                {
                    _thirdPanel.GetComponent<Animator>().Play($"Connected" +
                        $"{_thirdPanel.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _thirdPanel.GetComponent<PanelChangeImage>().IsConnecteed = true;
                }
            }            
        }
    }
}