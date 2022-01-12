using System;
using System.Collections.Generic;

namespace MCasado.Scoreboards
{
    [Serializable]
    public class ScoreBoardSaveData
    {
        public List<ScoreBoardEntryData> highscores = new List<ScoreBoardEntryData>();
    }
}
