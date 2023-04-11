using System;
using System.Collections.Generic;

namespace Multipliers
{
    [Serializable]
    public class GameData 
    {
        public bool SoundsIsActive;
        public bool MusicIsActive;

        public int HardScore;
        public int MediumScore;
        public int EasyScore;

        public int LastGameScore;
        public int SelectedDifficulty;

        public bool GameIsOver;

        //--------------------------------------------------------

        public float TimeOnTimer;
        public int DifficultyIndex;

        public List<int> FirstPanelMultipliers;
        public List<int> SecondPanelMultipliers;
        public List<int> ThirdPanelMultipliers;
        public List<int> ReserveMultipliers;

        public string[] FirstPlaneMultipliers;
        public bool[] FirstPlaneMultiplication;
        public string FirstPlaneCompositionRight;

        public string[] SecondPlaneMultipliers;
        public bool[] SecondPlaneMultiplication;
        public string SecondPlaneCompositionRight;

        public string[] ThirdPlaneMultipliers;
        public bool[] ThirdPlaneMultiplication;
        public string ThirdPlaneCompositionRight;

        public string[] ReservePlaneMultipliers;

        public GameData()
        {
            SoundsIsActive = true;
            MusicIsActive = true;

            HardScore = 0;
            MediumScore = 0;
            EasyScore = 0;

            LastGameScore = 0;
            SelectedDifficulty = 0;

            GameIsOver = true;

            //------------------------------------------------------------

            TimeOnTimer = 0f;
            DifficultyIndex = 0;

            FirstPanelMultipliers = new List<int>();
            SecondPanelMultipliers = new List<int>();
            ThirdPanelMultipliers = new List<int>();
            ReserveMultipliers = new List<int>();

            FirstPlaneMultipliers = new string[6];
            FirstPlaneMultiplication = new bool[5];
            FirstPlaneCompositionRight = "";

            SecondPlaneMultipliers = new string[6];
            SecondPlaneMultiplication = new bool[5];
            SecondPlaneCompositionRight = "";

            ThirdPlaneMultipliers = new string[6];
            ThirdPlaneMultiplication = new bool[5];
            ThirdPlaneCompositionRight = "";

            ReservePlaneMultipliers = new string[10];
        }
    }
}