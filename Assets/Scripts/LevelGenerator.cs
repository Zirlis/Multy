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
        [SerializeField] private TextMeshProUGUI _firstCompositionRight;
        [SerializeField] private TextMeshProUGUI _firstCompositionLeft;
        [Space(5)]
        [SerializeField] private TextMeshProUGUI _firstMultiplier1;
        [SerializeField] private TextMeshProUGUI _firstMultiplier2;
        [SerializeField] private TextMeshProUGUI _firstMultiplier3;
        [SerializeField] private TextMeshProUGUI _firstMultiplier4;
        [SerializeField] private TextMeshProUGUI _firstMultiplier5;
        [SerializeField] private TextMeshProUGUI _firstMultiplier6;
        [Space(5)]
        [SerializeField] private GameObject _firstMultiplication12;
        [SerializeField] private GameObject _firstMultiplication23;
        [SerializeField] private GameObject _firstMultiplication34;
        [SerializeField] private GameObject _firstMultiplication45;
        [SerializeField] private GameObject _firstMultiplication56;
        #endregion

        #region SecondPanel
        [Header("SecondPanel")]
        [SerializeField] private TextMeshProUGUI _secondCompositionRight;
        [SerializeField] private TextMeshProUGUI _secondCompositionLeft;
        [Space(5)]
        [SerializeField] private TextMeshProUGUI _secondMultiplier1;
        [SerializeField] private TextMeshProUGUI _secondMultiplier2;
        [SerializeField] private TextMeshProUGUI _secondMultiplier3;
        [SerializeField] private TextMeshProUGUI _secondMultiplier4;
        [SerializeField] private TextMeshProUGUI _secondMultiplier5;
        [SerializeField] private TextMeshProUGUI _secondMultiplier6;
        [Space(5)]
        [SerializeField] private GameObject _secondMultiplication12;
        [SerializeField] private GameObject _secondMultiplication23;
        [SerializeField] private GameObject _secondMultiplication34;
        [SerializeField] private GameObject _secondMultiplication45;
        [SerializeField] private GameObject _secondMultiplication56;
        #endregion

        #region ThiedPanel
        [Header("ThiedPanel")]
        [SerializeField] private TextMeshProUGUI _thirdCompositionRight;
        [SerializeField] private TextMeshProUGUI _thirdCompositionLeft;
        [Space(5)]
        [SerializeField] private TextMeshProUGUI _thirdMultiplier1;
        [SerializeField] private TextMeshProUGUI _thirdMultiplier2;
        [SerializeField] private TextMeshProUGUI _thirdMultiplier3;
        [SerializeField] private TextMeshProUGUI _thirdMultiplier4;
        [SerializeField] private TextMeshProUGUI _thirdMultiplier5;
        [SerializeField] private TextMeshProUGUI _thirdMultiplier6;
        [Space(5)]
        [SerializeField] private GameObject _thirdMultiplication12;
        [SerializeField] private GameObject _thirdMultiplication23;
        [SerializeField] private GameObject _thirdMultiplication34;
        [SerializeField] private GameObject _thirdMultiplication45;
        [SerializeField] private GameObject _thirdMultiplication56;
        #endregion

        #region Reserve
        [Header("Reserve")]
        [SerializeField] private TextMeshProUGUI _reservMultiplier1;
        [SerializeField] private TextMeshProUGUI _reservMultiplier2;
        [SerializeField] private TextMeshProUGUI _reservMultiplier3;
        [SerializeField] private TextMeshProUGUI _reservMultiplier4;
        [SerializeField] private TextMeshProUGUI _reservMultiplier5;
        [SerializeField] private TextMeshProUGUI _reservMultiplier6;
        [SerializeField] private TextMeshProUGUI _reservMultiplier7;
        [SerializeField] private TextMeshProUGUI _reservMultiplier8;
        [SerializeField] private TextMeshProUGUI _reservMultiplier9;
        [SerializeField] private TextMeshProUGUI _reservMultiplier10;
        #endregion
        #endregion

        private SaveManagerGameScene _saveManagerGameScene;
        [HideInInspector] public List<int> AvailableMultipliers = new List<int>();
        private List<int> _levelMultipliers = new List<int>();
        public int DifficultyInGame;        

        void Start()
        {
            if (SecondaryInformation.IsContinuation == true)
            {
                //загрузка
            }
            else
            {
                _saveManagerGameScene = GetComponent<SaveManagerGameScene>();
                GenerateAvailableMultipliers(_saveManagerGameScene.GameData.SelectedDifficulty);
                NewLevel();
            }
        }

        private void GenerateAvailableMultipliers(int selectedDifficulty)
        {
            switch (selectedDifficulty)
            {
                case 1:
                    DifficultyInGame = 9;
                    MultipliersGeneration();
                    AvailableMultipliers.Add(2);
                    AvailableMultipliers.Add(5);
                    break;
                case 2:
                    DifficultyInGame = 15;
                    MultipliersGeneration();
                    break;
                case 3:
                    DifficultyInGame = 21;
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
            for(int i = 2; i <= DifficultyInGame; i++)
            {
                AvailableMultipliers.Add(i);
            }
        }

        public void NewLevel()
        {
            _firstCompositionRight.SetText($"{GenerateLine()}");
            _secondCompositionRight.SetText($"{GenerateLine()}");
            _thirdCompositionRight.SetText($"{GenerateLine()}");

            AddReserv();
            foreach (int multiplier in _levelMultipliers)
            {
                SetMultipliers(multiplier);
            }

            int firstCompositionLeft = 0;
            if(_firstMultiplier1.text != "")
            {
                firstCompositionLeft = Int32.Parse(_firstMultiplier1.text);
                if (_firstMultiplier2.text != "")
                {
                    firstCompositionLeft *= Int32.Parse(_firstMultiplier2.text);
                    if (_firstMultiplier3.text != "")
                    {
                        firstCompositionLeft *= Int32.Parse(_firstMultiplier3.text);
                        if (_firstMultiplier4.text != "")
                        {
                            firstCompositionLeft *= Int32.Parse(_firstMultiplier4.text);
                            if (_firstMultiplier5.text != "")
                            {
                                firstCompositionLeft *= Int32.Parse(_firstMultiplier5.text);
                                if (_firstMultiplier6.text != "")
                                {
                                    firstCompositionLeft *= Int32.Parse(_firstMultiplier6.text);
                                }
                            }
                        }
                    }
                }
            }
            _firstCompositionLeft.SetText($"{firstCompositionLeft}");

            int secondCompositionLeft = 0;
            if (_secondMultiplier1.text != "")
            {
                secondCompositionLeft = Int32.Parse(_secondMultiplier1.text);
                if (_secondMultiplier2.text != "")
                {
                    secondCompositionLeft *= Int32.Parse(_secondMultiplier2.text);
                    if (_secondMultiplier3.text != "")
                    {
                        secondCompositionLeft *= Int32.Parse(_secondMultiplier3.text);
                        if (_secondMultiplier4.text != "")
                        {
                            secondCompositionLeft *= Int32.Parse(_secondMultiplier4.text);
                            if (_secondMultiplier5.text != "")
                            {
                                secondCompositionLeft *= Int32.Parse(_secondMultiplier5.text);
                                if (_secondMultiplier6.text != "")
                                {
                                    secondCompositionLeft *= Int32.Parse(_secondMultiplier6.text);
                                }
                            }
                        }
                    }
                }
            }
            _secondCompositionLeft.SetText($"{secondCompositionLeft}");

            int thirdCompositionLeft = 0;
            if (_thirdMultiplier1.text != "")
            {
                thirdCompositionLeft = Int32.Parse(_thirdMultiplier1.text);
                if (_thirdMultiplier2.text != "")
                {
                    thirdCompositionLeft *= Int32.Parse(_thirdMultiplier2.text);
                    if (_thirdMultiplier3.text != "")
                    {
                        thirdCompositionLeft *= Int32.Parse(_thirdMultiplier3.text);
                        if (_thirdMultiplier4.text != "")
                        {
                            thirdCompositionLeft *= Int32.Parse(_thirdMultiplier4.text);
                            if (_thirdMultiplier5.text != "")
                            {
                                thirdCompositionLeft *= Int32.Parse(_thirdMultiplier5.text);
                                if (_thirdMultiplier6.text != "")
                                {
                                    thirdCompositionLeft *= Int32.Parse(_thirdMultiplier6.text);
                                }
                            }
                        }
                    }
                }
            }
            _thirdCompositionLeft.SetText($"{thirdCompositionLeft}");
        }

        private int GenerateLine()
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
                        return composition;
                    }
                    else
                    {
                        return GenerateLine();
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
                        return composition;
                    }
                    else
                    {
                        return GenerateLine();
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
                    return composition;
                }
                else
                {
                    return GenerateLine();
                }
            }
        }

        private void AddReserv()
        {
            if (UnityEngine.Random.Range(0, 100) < DifficultyInGame)
            {
                _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                if (UnityEngine.Random.Range(0, 100) < DifficultyInGame)
                {
                    _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                    if (UnityEngine.Random.Range(0, 100) < DifficultyInGame)
                    {
                        _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                        if (UnityEngine.Random.Range(0, 100) < DifficultyInGame)
                        {
                            _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                            if (UnityEngine.Random.Range(0, 100) < DifficultyInGame)
                            {
                                _levelMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
                                if (UnityEngine.Random.Range(0, 100) < DifficultyInGame)
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
                    if (_reservMultiplier1.text == "")
                    {
                        _reservMultiplier1.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier2.text == "")
                    {
                        _reservMultiplier2.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier3.text == "")
                    {
                        _reservMultiplier3.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier4.text == "")
                    {
                        _reservMultiplier4.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier5.text == "")
                    {
                        _reservMultiplier5.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier6.text == "")
                    {
                        _reservMultiplier6.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier7.text == "")
                    {
                        _reservMultiplier7.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier8.text == "")
                    {
                        _reservMultiplier8.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier9.text == "")
                    {
                        _reservMultiplier9.SetText($"{multiplier}");
                    }
                    else if (_reservMultiplier10.text == "")
                    {
                        _reservMultiplier10.SetText($"{multiplier}");
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                        break;
                case 1:
                    if (_firstMultiplier1.text == "")
                    {
                        _firstMultiplier1.SetText($"{multiplier}");
                    }
                    else if (_firstMultiplier2.text == "")
                    {
                        _firstMultiplier2.SetText($"{multiplier}");
                        _firstMultiplication12.SetActive(true);
                    }
                    else if (_firstMultiplier3.text == "")
                    {
                        _firstMultiplier3.SetText($"{multiplier}");
                        _firstMultiplication23.SetActive(true);
                    }
                    else if (_firstMultiplier4.text == "")
                    {
                        _firstMultiplier4.SetText($"{multiplier}");
                        _firstMultiplication34.SetActive(true);
                    }
                    else if (_firstMultiplier5.text == "")
                    {
                        _firstMultiplier5.SetText($"{multiplier}");
                        _firstMultiplication45.SetActive(true);
                    }
                    else if (_firstMultiplier6.text == "")
                    {
                        _firstMultiplier6.SetText($"{multiplier}");
                        _firstMultiplication56.SetActive(true);
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                    break;
                case 2:
                    if (_secondMultiplier1.text == "")
                    {
                        _secondMultiplier1.SetText($"{multiplier}");
                    }
                    else if (_secondMultiplier2.text == "")
                    {
                        _secondMultiplier2.SetText($"{multiplier}");
                        _secondMultiplication12.SetActive(true);
                    }
                    else if (_secondMultiplier3.text == "")
                    {
                        _secondMultiplier3.SetText($"{multiplier}");
                        _secondMultiplication23.SetActive(true);
                    }
                    else if (_secondMultiplier4.text == "")
                    {
                        _secondMultiplier4.SetText($"{multiplier}");
                        _secondMultiplication34.SetActive(true);
                    }
                    else if (_secondMultiplier5.text == "")
                    {
                        _secondMultiplier5.SetText($"{multiplier}");
                        _secondMultiplication45.SetActive(true);
                    }
                    else if (_secondMultiplier6.text == "")
                    {
                        _secondMultiplier6.SetText($"{multiplier}");
                        _secondMultiplication56.SetActive(true);
                    }
                    else
                    {
                        SetMultipliers(multiplier);
                    }
                    break;
                case 3:
                    if (_thirdMultiplier1.text == "")
                    {
                        _thirdMultiplier1.SetText($"{multiplier}");
                    }
                    else if (_thirdMultiplier2.text == "")
                    {
                        _thirdMultiplier2.SetText($"{multiplier}");
                        _thirdMultiplication12.SetActive(true);
                    }
                    else if (_thirdMultiplier3.text == "")
                    {
                        _thirdMultiplier3.SetText($"{multiplier}");
                        _thirdMultiplication23.SetActive(true);
                    }
                    else if (_thirdMultiplier4.text == "")
                    {
                        _thirdMultiplier4.SetText($"{multiplier}");
                        _thirdMultiplication34.SetActive(true);
                    }
                    else if (_thirdMultiplier5.text == "")
                    {
                        _thirdMultiplier5.SetText($"{multiplier}");
                        _thirdMultiplication45.SetActive(true);
                    }
                    else if (_thirdMultiplier6.text == "")
                    {
                        _thirdMultiplier6.SetText($"{multiplier}");
                        _thirdMultiplication56.SetActive(true);
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