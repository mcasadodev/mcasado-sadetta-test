using System.IO;
using UnityEngine;
using MCasado.Utils;

namespace MCasado.Scoreboards
{
    using MCasado.Events;
    using MCasado.UI;

    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO _score = default;
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        public ScoreBoardEntryData testEntryData = new ScoreBoardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            ScoreBoardSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);
            SaveScores(savedScores);
            //Debug.Log(SavePath);
        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntryData);
        }

        private void OnEnable()
        {
            if (_score != null)
            {
                _score.OnEventRaised += SetPlayerScore;
            }
        }
        private void OnDisable()
        {
            if (_score != null)
            {
                _score.OnEventRaised -= SetPlayerScore;
            }
        }
        private void SetPlayerScore(int score)
        {
            testEntryData.entryScore = score;
        }

        public void AddEntry(ScoreBoardEntryData scoreBoardEntryData)
        {
            ScoreBoardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (scoreBoardEntryData.entryName == savedScores.highscores[i].entryName && scoreBoardEntryData.entryScore == savedScores.highscores[i].entryScore) return;

                if (scoreBoardEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    ModalWindow.Show("Do you want to load this slot?", () =>
                    {
                        scoreBoardEntryData.entryName = ModalWindow.playerName.text;
                        savedScores.highscores.Insert(i, scoreBoardEntryData);
                        scoreAdded = true;
                        if (savedScores.highscores.Count > maxScoreboardEntries)
                        {
                            savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);

                        }
                        UpdateUI(savedScores);
                        SaveScores(savedScores);

                    });
                    break;
                }
            }

            if (!scoreAdded && savedScores.highscores.Count < 1)
            {
                ModalWindow.Show("Do you want to load this slot?", () =>
                {
                    scoreBoardEntryData.entryName = ModalWindow.playerName.text;
                    savedScores.highscores.Add(scoreBoardEntryData);
                    if (savedScores.highscores.Count > maxScoreboardEntries)
                    {
                        savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);

                    }
                    UpdateUI(savedScores);
                    SaveScores(savedScores);

                });
            }
        }

        private void UpdateUI(ScoreBoardSaveData savedScores)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreBoardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreBoardEntryUI>().Initialize(highscore);
            }
        }

        private ScoreBoardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreBoardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreBoardSaveData>(json);
            }
        }

        private void SaveScores(ScoreBoardSaveData scoreBoardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreBoardSaveData, true);
                stream.Write(json);
            }
        }
    }
}