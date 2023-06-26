using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class LevelGenerator : MonoBehaviour
    {
        #region Panels
        #region FirstPanel
        [Header("FirstPanel")]
        public TextMeshProUGUI FirstCompositionRight;
        public TextMeshProUGUI FirstCompositionLeft;
        [Space(5)]
        public TextMeshProUGUI FirstMultiplier1;
        public TextMeshProUGUI FirstMultiplier2;
        public TextMeshProUGUI FirstMultiplier3;
        public TextMeshProUGUI FirstMultiplier4;
        public TextMeshProUGUI FirstMultiplier5;
        public TextMeshProUGUI FirstMultiplier6;
        [Space(5)]
        public GameObject FirstMultiplication12;
        public GameObject FirstMultiplication23;
        public GameObject FirstMultiplication34;
        public GameObject FirstMultiplication45;
        public GameObject FirstMultiplication56;
        #endregion

        #region SecondPanel
        [Header("SecondPanel")]
        public TextMeshProUGUI SecondCompositionRight;
        public TextMeshProUGUI SecondCompositionLeft;
        [Space(5)]
        public TextMeshProUGUI SecondMultiplier1;
        public TextMeshProUGUI SecondMultiplier2;
        public TextMeshProUGUI SecondMultiplier3;
        public TextMeshProUGUI SecondMultiplier4;
        public TextMeshProUGUI SecondMultiplier5;
        public TextMeshProUGUI SecondMultiplier6;
        [Space(5)]
        public GameObject SecondMultiplication12;
        public GameObject SecondMultiplication23;
        public GameObject SecondMultiplication34;
        public GameObject SecondMultiplication45;
        public GameObject SecondMultiplication56;
        #endregion

        #region ThiedPanel
        [Header("ThiedPanel")]
        public TextMeshProUGUI ThirdCompositionRight;
        public TextMeshProUGUI ThirdCompositionLeft;
        [Space(5)]
        public TextMeshProUGUI ThirdMultiplier1;
        public TextMeshProUGUI ThirdMultiplier2;
        public TextMeshProUGUI ThirdMultiplier3;
        public TextMeshProUGUI ThirdMultiplier4;
        public TextMeshProUGUI ThirdMultiplier5;
        public TextMeshProUGUI ThirdMultiplier6;
        [Space(5)]
        public GameObject ThirdMultiplication12;
        public GameObject ThirdMultiplication23;
        public GameObject ThirdMultiplication34;
        public GameObject ThirdMultiplication45;
        public GameObject ThirdMultiplication56;
        #endregion

        #region Reserve
        [Header("Reserve")]
        public TextMeshProUGUI ReservMultiplier1;
        public TextMeshProUGUI ReservMultiplier2;
        public TextMeshProUGUI ReservMultiplier3;
        public TextMeshProUGUI ReservMultiplier4;
        public TextMeshProUGUI ReservMultiplier5;
        public TextMeshProUGUI ReservMultiplier6;
        public TextMeshProUGUI ReservMultiplier7;
        public TextMeshProUGUI ReservMultiplier8;
        public TextMeshProUGUI ReservMultiplier9;
        public TextMeshProUGUI ReservMultiplier10;
        #endregion
        #endregion

        private SaveManagerGameScene _saveManagerGameScene;
        [HideInInspector] public List<int> AvailableMultipliers;
        private List<int> _levelMultipliers;
        public List<int> FirstPanelMultipliers;
        public List<int> SecondPanelMultipliers;
        public List<int> ThirdPanelMultipliers;
        public List<int> ReserveMultipliers;
        [SerializeField] private NextLevel _nextLevel;

        void Start()
        {
            _saveManagerGameScene = GetComponent<SaveManagerGameScene>();

            if (!SecondaryInformation.IsContinuation)
            {                
                _saveManagerGameScene.GameData.LastGameScore = 0;
                _saveManagerGameScene.GameData.DifficultyIndex = 0;
                NewLevel();
            }            
        }

        public void NewLevel()
        {
            AvailableMultipliers = new List<int>();
            _levelMultipliers = new List<int>();
            GenerateAvailableMultipliers(_saveManagerGameScene.GameData.SelectedDifficulty, false);
            GenerateLevel();

            _saveManagerGameScene.GameData.LevelIsOver = false;
            _saveManagerGameScene.GameData.GameIsOver = false;
            _saveManagerGameScene.Save();            
        }

        private void GenerateAvailableMultipliers(int selectedDifficulty, bool replay)
        {
            var gameData = _saveManagerGameScene.GameData;
            float reserveCount = 0f;

            if (!replay)
            {
                switch (selectedDifficulty)
                {
                    case 1:
                        gameData.DifficultyIndex += 0.7f;
                        if (gameData.DifficultyIndex < 3)
                        {
                            gameData.DifficultyIndex = 3;
                        }
                        break;
                    case 2:
                        gameData.DifficultyIndex += 1.4f;
                        if (gameData.DifficultyIndex < 4)
                        {
                            gameData.DifficultyIndex = 5;
                        }
                        reserveCount++;
                        break;
                    case 3:
                        gameData.DifficultyIndex += 2.1f;
                        if (gameData.DifficultyIndex < 5)
                        {
                            gameData.DifficultyIndex = 5;
                        }
                        reserveCount += 2;
                        break;
                }
            }

            if(selectedDifficulty == 1)
            {
                AvailableMultipliers.Add(2);
            }

            for (int i = 2; i <= gameData.DifficultyIndex; i++)
            {
                AvailableMultipliers.Add(i);
            }

            reserveCount += gameData.DifficultyIndex / 3;

            while (ReserveMultipliers.Count < 8 && reserveCount > 0)
            {
                ReserveMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                reserveCount--;
            }
        }

        public void GenerateLevel()
        {
            FirstPanelMultipliers.Clear();
            SecondPanelMultipliers.Clear();
            ThirdPanelMultipliers.Clear();

            FirstCompositionRight.SetText($"{GenerateLine(FirstPanelMultipliers)}");
            SecondCompositionRight.SetText($"{GenerateLine(SecondPanelMultipliers)}");
            ThirdCompositionRight.SetText($"{GenerateLine(ThirdPanelMultipliers)}");

            for(int i = 0; i < ReserveMultipliers.Count; i++)
            {
                _levelMultipliers.Add(ReserveMultipliers[i]);
            }
            ReserveMultipliers.Clear();

            for (int i = 0; i < FirstPanelMultipliers.Count; i++)
            {
                _levelMultipliers.Add(FirstPanelMultipliers[i]);
            }

            for (int i = 0; i < SecondPanelMultipliers.Count; i++)
            {
                _levelMultipliers.Add(SecondPanelMultipliers[i]);
            }

            for (int i = 0; i < ThirdPanelMultipliers.Count; i++)
            {
                _levelMultipliers.Add(ThirdPanelMultipliers[i]);
            }

            foreach (int multiplier in _levelMultipliers)
            {
                SetMultipliers(multiplier);
            }

            int firstCompositionLeft = 0;
            if(FirstMultiplier1.text != "")
            {
                firstCompositionLeft = Int32.Parse(FirstMultiplier1.text);
                if (FirstMultiplier2.text != "")
                {
                    firstCompositionLeft *= Int32.Parse(FirstMultiplier2.text);
                    if (FirstMultiplier3.text != "")
                    {
                        firstCompositionLeft *= Int32.Parse(FirstMultiplier3.text);
                        if (FirstMultiplier4.text != "")
                        {
                            firstCompositionLeft *= Int32.Parse(FirstMultiplier4.text);
                            if (FirstMultiplier5.text != "")
                            {
                                firstCompositionLeft *= Int32.Parse(FirstMultiplier5.text);
                                if (FirstMultiplier6.text != "")
                                {
                                    firstCompositionLeft *= Int32.Parse(FirstMultiplier6.text);
                                }
                            }
                        }
                    }
                }
            }

            if (firstCompositionLeft != 0)
            {
                FirstCompositionLeft.SetText($"{firstCompositionLeft}");
            }
            else
            {
                FirstCompositionLeft.SetText("");
            }

            int secondCompositionLeft = 0;
            if (SecondMultiplier1.text != "")
            {
                secondCompositionLeft = Int32.Parse(SecondMultiplier1.text);
                if (SecondMultiplier2.text != "")
                {
                    secondCompositionLeft *= Int32.Parse(SecondMultiplier2.text);
                    if (SecondMultiplier3.text != "")
                    {
                        secondCompositionLeft *= Int32.Parse(SecondMultiplier3.text);
                        if (SecondMultiplier4.text != "")
                        {
                            secondCompositionLeft *= Int32.Parse(SecondMultiplier4.text);
                            if (SecondMultiplier5.text != "")
                            {
                                secondCompositionLeft *= Int32.Parse(SecondMultiplier5.text);
                                if (SecondMultiplier6.text != "")
                                {
                                    secondCompositionLeft *= Int32.Parse(SecondMultiplier6.text);
                                }
                            }
                        }
                    }
                }
            }

            if (secondCompositionLeft != 0)
            {
                SecondCompositionLeft.SetText($"{secondCompositionLeft}");
            }
            else
            {
                SecondCompositionLeft.SetText("");
            }

            int thirdCompositionLeft = 0;
            if (ThirdMultiplier1.text != "")
            {
                thirdCompositionLeft = Int32.Parse(ThirdMultiplier1.text);
                if (ThirdMultiplier2.text != "")
                {
                    thirdCompositionLeft *= Int32.Parse(ThirdMultiplier2.text);
                    if (ThirdMultiplier3.text != "")
                    {
                        thirdCompositionLeft *= Int32.Parse(ThirdMultiplier3.text);
                        if (ThirdMultiplier4.text != "")
                        {
                            thirdCompositionLeft *= Int32.Parse(ThirdMultiplier4.text);
                            if (ThirdMultiplier5.text != "")
                            {
                                thirdCompositionLeft *= Int32.Parse(ThirdMultiplier5.text);
                                if (ThirdMultiplier6.text != "")
                                {
                                    thirdCompositionLeft *= Int32.Parse(ThirdMultiplier6.text);
                                }
                            }
                        }
                    }
                }
            }

            if (thirdCompositionLeft != 0)
            {
                ThirdCompositionLeft.SetText($"{thirdCompositionLeft}");
            }
            else
            {
                ThirdCompositionLeft.SetText("");
            }            

            if (FirstCompositionLeft.text == FirstCompositionRight.text || SecondCompositionLeft.text ==
                SecondCompositionRight.text || ThirdCompositionLeft.text == ThirdCompositionRight.text)
            {
                _nextLevel.ClearAllLines();

                AvailableMultipliers = new List<int>();
                _levelMultipliers = new List<int>();
                GenerateAvailableMultipliers(_saveManagerGameScene.GameData.SelectedDifficulty, true);
                GenerateLevel();
            }
        }

        private int GenerateLine(List<int> multipliers)
        {
            int[] mults = new int[6]
            {
                AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)],
                AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)],
                AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)],
                AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)],
                AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)],
                AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]
            };        

            int composition = 1;

            for (int i = 0; i < 6; i++)
            {
                composition *= mults[i];
                if (composition > Math.Pow((_saveManagerGameScene.GameData.DifficultyIndex / 2) + 1, 5) * 2)
                {
                    return GenerateLine(multipliers);
                }
                if (composition > Math.Pow((_saveManagerGameScene.GameData.DifficultyIndex / 2) + 1, 5) / 2)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        multipliers.Add(mults[j]);
                    }
                    return composition;
                }
            }

            return GenerateLine(multipliers);           
        }

        private void SetMultipliers(int multiplier)
        {
            int rnd = UnityEngine.Random.Range(0, 4);
            switch (rnd)
            {                
                case 0:
                    if (ReservMultiplier1.text == "")
                    {
                        ReservMultiplier1.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier2.text == "")
                    {
                        ReservMultiplier2.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier3.text == "")
                    {
                        ReservMultiplier3.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier4.text == "")
                    {
                        ReservMultiplier4.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier5.text == "")
                    {
                        ReservMultiplier5.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier6.text == "")
                    {
                        ReservMultiplier6.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier7.text == "")
                    {
                        ReservMultiplier7.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier8.text == "")
                    {
                        ReservMultiplier8.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier9.text == "")
                    {
                        ReservMultiplier9.SetText($"{multiplier}");
                    }
                    else if (ReservMultiplier10.text == "")
                    {
                        ReservMultiplier10.SetText($"{multiplier}");
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                        break;
                case 1:
                    if (FirstMultiplier1.text == "")
                    {
                        FirstMultiplier1.SetText($"{multiplier}");
                    }
                    else if (FirstMultiplier2.text == "")
                    {
                        FirstMultiplier2.SetText($"{multiplier}");
                        FirstMultiplication12.SetActive(true);
                    }
                    else if (FirstMultiplier3.text == "")
                    {
                        FirstMultiplier3.SetText($"{multiplier}");
                        FirstMultiplication23.SetActive(true);
                    }
                    else if (FirstMultiplier4.text == "")
                    {
                        FirstMultiplier4.SetText($"{multiplier}");
                        FirstMultiplication34.SetActive(true);
                    }
                    else if (FirstMultiplier5.text == "")
                    {
                        FirstMultiplier5.SetText($"{multiplier}");
                        FirstMultiplication45.SetActive(true);
                    }
                    else if (FirstMultiplier6.text == "")
                    {
                        FirstMultiplier6.SetText($"{multiplier}");
                        FirstMultiplication56.SetActive(true);
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                    break;
                case 2:
                    if (SecondMultiplier1.text == "")
                    {
                        SecondMultiplier1.SetText($"{multiplier}");
                    }
                    else if (SecondMultiplier2.text == "")
                    {
                        SecondMultiplier2.SetText($"{multiplier}");
                        SecondMultiplication12.SetActive(true);
                    }
                    else if (SecondMultiplier3.text == "")
                    {
                        SecondMultiplier3.SetText($"{multiplier}");
                        SecondMultiplication23.SetActive(true);
                    }
                    else if (SecondMultiplier4.text == "")
                    {
                        SecondMultiplier4.SetText($"{multiplier}");
                        SecondMultiplication34.SetActive(true);
                    }
                    else if (SecondMultiplier5.text == "")
                    {
                        SecondMultiplier5.SetText($"{multiplier}");
                        SecondMultiplication45.SetActive(true);
                    }
                    else if (SecondMultiplier6.text == "")
                    {
                        SecondMultiplier6.SetText($"{multiplier}");
                        SecondMultiplication56.SetActive(true);
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                    break;
                case 3:
                    if (ThirdMultiplier1.text == "")
                    {
                        ThirdMultiplier1.SetText($"{multiplier}");
                    }
                    else if (ThirdMultiplier2.text == "")
                    {
                        ThirdMultiplier2.SetText($"{multiplier}");
                        ThirdMultiplication12.SetActive(true);
                    }
                    else if (ThirdMultiplier3.text == "")
                    {
                        ThirdMultiplier3.SetText($"{multiplier}");
                        ThirdMultiplication23.SetActive(true);
                    }
                    else if (ThirdMultiplier4.text == "")
                    {
                        ThirdMultiplier4.SetText($"{multiplier}");
                        ThirdMultiplication34.SetActive(true);
                    }
                    else if (ThirdMultiplier5.text == "")
                    {
                        ThirdMultiplier5.SetText($"{multiplier}");
                        ThirdMultiplication45.SetActive(true);
                    }
                    else if (ThirdMultiplier6.text == "")
                    {
                        ThirdMultiplier6.SetText($"{multiplier}");
                        ThirdMultiplication56.SetActive(true);
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                    break;
            }
        }
    }
}