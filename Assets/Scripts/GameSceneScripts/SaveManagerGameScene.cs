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
        [SerializeField] private GameObject[] _panels = new GameObject[4];

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
            GameData.ReserveMultipliers = _levelGenerator.ReservePanalMultipliers;

            for(int i = 0; i < 6; i++)
            {
                GameData.FirstPlaneMultipliers[i] = _panels[0].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text;
                GameData.SecondPlaneMultipliers[i] = _panels[1].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text;
                GameData.ThirdPlaneMultipliers[i] = _panels[2].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text;
            }

            for(int i = 0; i < 10; i++)
            {
                GameData.ReservePlaneMultipliers[i] = _panels[3].transform.GetChild(i).gameObject.
                    GetComponent<TextMeshProUGUI>().text;
            }

            for (int i = 0; i < 5; i++)
            {
                GameData.FirstPlaneMultiplication[i] = _panels[0].transform.GetChild(i + 6).gameObject.activeInHierarchy;
                GameData.SecondPlaneMultiplication[i] = _panels[1].transform.GetChild(i + 6).gameObject.activeInHierarchy;
                GameData.ThirdPlaneMultiplication[i] = _panels[2].transform.GetChild(i + 6).gameObject.activeInHierarchy;
            }

            GameData.FirstPlaneCompositionRight = _panels[0].transform.GetChild(11).GetComponent<TextMeshProUGUI>().text;
            GameData.SecondPlaneCompositionRight = _panels[1].transform.GetChild(11).GetComponent<TextMeshProUGUI>().text;
            GameData.ThirdPlaneCompositionRight = _panels[2].transform.GetChild(11).GetComponent<TextMeshProUGUI>().text;

            _storage.Save(GameData);
        }

        public void Load()
        {
            GameData = (GameData)_storage.Load(new GameData());

            _soundsToggle.GetComponent<SoundsToggleInGameScene>().OnSwitch(GameData.SoundsIsActive, true);
            _musicToggle.GetComponent<MusicToggleInGameScene>().OnSwitch(GameData.MusicIsActive, true);

            if (SecondaryInformation.IsContinuation)
            {
                _timer.TimeOnTimer = GameData.TimeOnTimer + 1;
                _timer.SetTimeOnTimer();

                _levelGenerator.FirstPanelMultipliers = GameData.FirstPanelMultipliers;
                _levelGenerator.SecondPanelMultipliers = GameData.SecondPanelMultipliers;
                _levelGenerator.ThirdPanelMultipliers = GameData.ThirdPanelMultipliers;
                _levelGenerator.ReservePanalMultipliers = GameData.ReserveMultipliers;

                for (int i = 0; i < 6; i++)
                {
                    _panels[0].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText(GameData.FirstPlaneMultipliers[i]);
                    _panels[1].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText(GameData.SecondPlaneMultipliers[i]);
                    _panels[2].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText(GameData.ThirdPlaneMultipliers[i]);
                }

                for (int i = 0; i < 10; i++)                
                    _panels[3].transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText(GameData.ReservePlaneMultipliers[i]);                

                for (int i = 0; i < 5; i++)
                {
                    _panels[0].transform.GetChild(i + 6).gameObject.SetActive(GameData.FirstPlaneMultiplication[i]);
                    _panels[1].transform.GetChild(i + 6).gameObject.SetActive(GameData.SecondPlaneMultiplication[i]);
                    _panels[2].transform.GetChild(i + 6).gameObject.SetActive(GameData.ThirdPlaneMultiplication[i]);
                }

                _panels[0].transform.GetChild(11).GetComponent<TextMeshProUGUI>().SetText(GameData.FirstPlaneCompositionRight);
                _panels[1].transform.GetChild(11).GetComponent<TextMeshProUGUI>().SetText(GameData.SecondPlaneCompositionRight);
                _panels[2].transform.GetChild(11).GetComponent<TextMeshProUGUI>().SetText(GameData.ThirdPlaneCompositionRight);

                for (int i = 0; i < 3; i++)
                    _newInLine.Recalculation(_panels[i]);

                for (int i = 0; i < 3; i++)
                    ConnectingCheck(_panels[i]);
            }            
        }

        private void ConnectingCheck(GameObject panel)
        {
            if (panel.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text ==
                    panel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text)
            {
                panel.GetComponent<Animator>().Play($"Connected" +
                    $"{panel.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                panel.GetComponent<PanelChangeImage>().IsConnecteed = true;
            }
        }
    }
}