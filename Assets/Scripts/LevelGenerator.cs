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
        public int DifficultyIndex;
        public List<int> FirstPanelMultipliers;
        public List<int> SecondPanelMultipliers;
        public List<int> ThirdPanelMultipliers;
        public List<int> ReserveMultipliers;

        void Start()
        {
            if (SecondaryInformation.IsContinuation == true)
            {
                //загрузка
            }
            else
            {
                _saveManagerGameScene = GetComponent<SaveManagerGameScene>();
                NewLevel();
            }
        }

        public void NewLevel()
        {
            AvailableMultipliers = new List<int>();
            _levelMultipliers = new List<int>();
            GenerateAvailableMultipliers(_saveManagerGameScene.GameData.SelectedDifficulty);
            GenerateLevel();
        }

        private void GenerateAvailableMultipliers(int selectedDifficulty)
        {

            //жижа
            switch (selectedDifficulty)
            {
                case 1:
                    DifficultyIndex = 9;
                    MultipliersGeneration();
                    AvailableMultipliers.Add(2);
                    AvailableMultipliers.Add(5);
                    break;
                case 2:
                    DifficultyIndex = 15;
                    MultipliersGeneration();
                    break;
                case 3:
                    DifficultyIndex = 21;
                    MultipliersGeneration();
                    AvailableMultipliers.Add(7);
                    AvailableMultipliers.Add(11);
                    AvailableMultipliers.Add(13);
                    AvailableMultipliers.Add(17);
                    break;
            }
        }

        private void MultipliersGeneration()
        {
            for(int i = 2; i <= DifficultyIndex; i++)
            {
                AvailableMultipliers.Add(i);
            }
        }

        public void GenerateLevel()
        {
            FirstPanelMultipliers.Clear();
            SecondPanelMultipliers.Clear();
            ThirdPanelMultipliers.Clear();
            ReserveMultipliers.Clear();
            //добавить генерацию резерва

            FirstCompositionRight.SetText($"{GenerateLine(FirstPanelMultipliers)}");
            SecondCompositionRight.SetText($"{GenerateLine(SecondPanelMultipliers)}");
            ThirdCompositionRight.SetText($"{GenerateLine(ThirdPanelMultipliers)}");

            AddReserv();
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
        }

        private int GenerateLine(List<int> multipliers)
        {
            int multiplier1 = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];
            int multiplier2 = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];
            int multiplier3 = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];
            int multiplier4 = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];
            int multiplier5;
            int multiplier6;

            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                multiplier5 = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];

                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    multiplier6 = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];

                    if(multiplier1 * multiplier2 * multiplier3 * multiplier4 * multiplier5 * multiplier6 <= 999999)
                    {
                        _levelMultipliers.Add(multiplier1);
                        _levelMultipliers.Add(multiplier2);
                        _levelMultipliers.Add(multiplier3);
                        _levelMultipliers.Add(multiplier4);
                        _levelMultipliers.Add(multiplier5);
                        _levelMultipliers.Add(multiplier6);
                        var composition = multiplier1 * multiplier2 * multiplier3 * multiplier4 * multiplier5 * multiplier6;

                        multipliers.Add(multiplier1);
                        multipliers.Add(multiplier2);
                        multipliers.Add(multiplier3);
                        multipliers.Add(multiplier4);
                        multipliers.Add(multiplier5);
                        multipliers.Add(multiplier6);
                        
                        return composition;
                    }
                    else
                    {
                        return GenerateLine(multipliers);
                    }
                }
                else
                {
                    if (multiplier1 * multiplier2 * multiplier3 * multiplier4 * multiplier5 <= 999999)
                    {
                        _levelMultipliers.Add(multiplier1);
                        _levelMultipliers.Add(multiplier2);
                        _levelMultipliers.Add(multiplier3);
                        _levelMultipliers.Add(multiplier4);
                        _levelMultipliers.Add(multiplier5);

                        var composition = multiplier1 * multiplier2 * multiplier3 * multiplier4 * multiplier5;

                        multipliers.Add(multiplier1);
                        multipliers.Add(multiplier2);
                        multipliers.Add(multiplier3);
                        multipliers.Add(multiplier4);
                        multipliers.Add(multiplier5);

                        return composition;
                    }
                    else
                    {
                        return GenerateLine(multipliers);
                    }
                }
            }  
            else
            {

                if (multiplier1 * multiplier2 * multiplier3 * multiplier4 <= 999999)
                {
                    _levelMultipliers.Add(multiplier1);
                    _levelMultipliers.Add(multiplier2);
                    _levelMultipliers.Add(multiplier3);
                    _levelMultipliers.Add(multiplier4);

                    var composition = multiplier1 * multiplier2 * multiplier3 * multiplier4;

                    multipliers.Add(multiplier1);
                    multipliers.Add(multiplier2);
                    multipliers.Add(multiplier3);
                    multipliers.Add(multiplier4);

                    return composition;
                }
                else
                {
                    return GenerateLine(multipliers);
                }
            }            
        }

        private void AddReserv()
        {
            if (UnityEngine.Random.Range(0, 100) < DifficultyIndex)
            {
                _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                if (UnityEngine.Random.Range(0, 100) < DifficultyIndex)
                {
                    _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                    if (UnityEngine.Random.Range(0, 100) < DifficultyIndex)
                    {
                        _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                        if (UnityEngine.Random.Range(0, 100) < DifficultyIndex)
                        {
                            _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                            if (UnityEngine.Random.Range(0, 100) < DifficultyIndex)
                            {
                                _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                                if (UnityEngine.Random.Range(0, 100) < DifficultyIndex)
                                {
                                    _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                                }
                            }
                        }
                    }
                }
            }
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