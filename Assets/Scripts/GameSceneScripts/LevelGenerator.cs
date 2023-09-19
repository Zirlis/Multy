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
        public TextMeshProUGUI[] FirstMultipliers = new TextMeshProUGUI[6];
        [Space(5)]
        public GameObject[] FirstMultiplications = new GameObject[5];
        #endregion

        #region SecondPanel
        [Header("SecondPanel")]
        public TextMeshProUGUI SecondCompositionRight;
        public TextMeshProUGUI SecondCompositionLeft;
        [Space(5)]
        public TextMeshProUGUI[] SecondMultipliers = new TextMeshProUGUI[6];
        [Space(5)]
        public GameObject[] SecondMultiplications = new GameObject[5];
        #endregion

        #region ThiedPanel
        [Header("ThiedPanel")]
        public TextMeshProUGUI ThirdCompositionRight;
        public TextMeshProUGUI ThirdCompositionLeft;
        [Space(5)]
        public TextMeshProUGUI[] ThirdMultipliers = new TextMeshProUGUI[6];
        [Space(5)]
        public GameObject[] ThirdMultiplications = new GameObject[5];
        #endregion

        #region Reserve
        [Header("Reserve")]
        public TextMeshProUGUI[] ReserveMultipliers = new TextMeshProUGUI[10];
        #endregion
        #endregion

        private SaveManagerGameScene _saveManagerGameScene;
        [HideInInspector] public List<int> AvailableMultipliers;
        private List<int> _levelMultipliers;
        [NonSerialized] public List<int> FirstPanelMultipliers = new List<int>();
        [NonSerialized] public List<int> SecondPanelMultipliers = new List<int>();
        [NonSerialized] public List<int> ThirdPanelMultipliers = new List<int>();
        [NonSerialized] public List<int> ReservePanalMultipliers = new List<int>();
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
                switch (selectedDifficulty)
                {
                    case 1:
                        gameData.DifficultyIndex += 0.6f;
                        if (gameData.DifficultyIndex < 3)                        
                            gameData.DifficultyIndex = 3;
                        
                        break;
                    case 2:
                        gameData.DifficultyIndex += 1.2f;
                        if (gameData.DifficultyIndex < 4)                        
                            gameData.DifficultyIndex = 4;
                        
                        reserveCount++;
                        break;
                    case 3:
                        gameData.DifficultyIndex += 1.8f;
                        if (gameData.DifficultyIndex < 5)                        
                            gameData.DifficultyIndex = 5;
                        
                        reserveCount += 2;
                        break;
                }            

            if(selectedDifficulty == 1)            
                AvailableMultipliers.Add(2);            

            for (int i = 2; i <= gameData.DifficultyIndex; i++)
            {
                AvailableMultipliers.Add(i);
            }

            reserveCount += gameData.DifficultyIndex / 3;

            while (ReservePanalMultipliers.Count < 8 && reserveCount > 0)
            {
                ReservePanalMultipliers.Add(AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)]);
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

            for(int i = 0; i < ReservePanalMultipliers.Count; i++)            
                _levelMultipliers.Add(ReservePanalMultipliers[i]);
            
            ReservePanalMultipliers.Clear();

            for (int i = 0; i < FirstPanelMultipliers.Count; i++)            
                _levelMultipliers.Add(FirstPanelMultipliers[i]);            

            for (int i = 0; i < SecondPanelMultipliers.Count; i++)            
                _levelMultipliers.Add(SecondPanelMultipliers[i]);            

            for (int i = 0; i < ThirdPanelMultipliers.Count; i++)            
                _levelMultipliers.Add(ThirdPanelMultipliers[i]);            

            foreach (int multiplier in _levelMultipliers)            
                SetMultipliers(multiplier);


            FirstCompositionLeft.SetText(GetComposition(FirstMultipliers));
            SecondCompositionLeft.SetText(GetComposition(SecondMultipliers));
            ThirdCompositionLeft.SetText(GetComposition(ThirdMultipliers));                      

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

        private string GetComposition(TextMeshProUGUI[] multipliers)
        {
            int composition = 1;

            foreach (TextMeshProUGUI multiplier in multipliers)
            {
                if (multiplier.text == "")
                    break;
                composition *= Int32.Parse(multiplier.text);
            }

            return composition == 1 ? "" : composition.ToString();
        }

        private int GenerateLine(List<int> multipliers)
        {
            int[] mults = new int[6];
            for (int i = 0; i < mults.Length; i++)
                mults[i] = AvailableMultipliers[UnityEngine.Random.Range(0, AvailableMultipliers.Count)];

            int composition = 1;

            for (int i = 0; i < 6; i++)
            {
                composition *= mults[i];
                if (composition > Math.Pow((_saveManagerGameScene.GameData.DifficultyIndex / 2) + 1, 5) * 2)                
                    return GenerateLine(multipliers);
                
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
                    for (int i = 0; i < ReserveMultipliers.Length; i++)
                    {
                        if (ReserveMultipliers[i].text == "")
                        {
                            ReserveMultipliers[i].SetText($"{multiplier}");
                            break;
                        }
                        else if (i == ReserveMultipliers.Length - 1)
                            SetMultipliers(multiplier);
                    }
                    break;
                case 1:
                    for (int i = 0; i < FirstMultipliers.Length; i++)
                    {
                        if (FirstMultipliers[i].text == "")
                        {
                            FirstMultipliers[i].SetText($"{multiplier}");
                            if (i > 0)
                                FirstMultiplications[i - 1].SetActive(true);
                            break;
                        }
                        else if (i == FirstMultipliers.Length - 1)
                            SetMultipliers(multiplier);
                    }
                    break;
                case 2:
                    for (int i = 0; i < SecondMultipliers.Length; i++)
                    {
                        if (SecondMultipliers[i].text == "")
                        {
                            SecondMultipliers[i].SetText($"{multiplier}");
                            if (i > 0)
                                SecondMultiplications[i - 1].SetActive(true);
                            break;
                        }
                        else if (i == SecondMultipliers.Length - 1)
                            SetMultipliers(multiplier);
                    }
                    break;
                case 3:
                    for (int i = 0; i < ThirdMultipliers.Length; i++)
                    {
                        if (ThirdMultipliers[i].text == "")
                        {
                            ThirdMultipliers[i].SetText($"{multiplier}");
                            if (i > 0)
                                ThirdMultiplications[i - 1].SetActive(true);
                            break;
                        }
                        else if (i == ThirdMultipliers.Length - 1)
                            SetMultipliers(multiplier);
                    }
                    break;
            }
        }
    }
}