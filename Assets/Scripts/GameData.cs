using System;

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
        public int LastGameDifficulty;

        public GameData()
        {
            SoundsIsActive = true;
            MusicIsActive = true;
            HardScore = 0;
            MediumScore = 0;
            EasyScore = 0;
            LastGameScore = 0;
            LastGameDifficulty = 0;
        }
    }
}
