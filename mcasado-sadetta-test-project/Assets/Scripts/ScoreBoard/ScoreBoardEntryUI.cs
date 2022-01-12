using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MCasado.Scoreboards
{
    public class ScoreBoardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialize(ScoreBoardEntryData scoreBoardEntryData)
        {
            entryNameText.text = scoreBoardEntryData.entryName;
            entryScoreText.text = scoreBoardEntryData.entryScore.ToString();
        }
    }
}
