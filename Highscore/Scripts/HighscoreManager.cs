using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using UnityEngine.UI;

namespace itfriedl.Highscores
{
    [Serializable]
    public struct ScoreModel
    {
        public string name;
        public int score;
       // public int time;
        public int moves;
        public string date;
    }

    [Serializable]
    public class ScoreModelData
    {
        public List<ScoreModel> ScoreList = new List<ScoreModel>();
        public string version = Application.version;
    }

    public class HighscoreManager : MonoBehaviour
    {
        [SerializeField] private int maxScoreEntries = 25;

        public GameObject scorePrefab;
        public RectTransform Holder;
        private string localPathO => $"{Application.persistentDataPath}/highscoreO.json";
        private string localPathV => $"{Application.persistentDataPath}/highscoreV.json";

        void Start()
        {
        }

        public void AddHighscore(ScoreModel scoreModel, int mode)
        {
            ScoreModelData scoreModelData = new ScoreModelData();

            scoreModelData = GetSavedScores(mode);

            bool scoreAdded = false;

            for (int i = 0; i < scoreModelData.ScoreList.Count; i++)
            {
                if (Convert.ToInt32(scoreModel.score) > Convert.ToInt32(scoreModelData.ScoreList[i].score))
                {
                    scoreModelData.ScoreList.Insert(i, scoreModel);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && scoreModelData.ScoreList.Count < maxScoreEntries)
            {
                scoreModelData.ScoreList.Add(scoreModel);
            }

            if (scoreModelData.ScoreList.Count > maxScoreEntries)
            {
                scoreModelData.ScoreList.RemoveRange(maxScoreEntries, scoreModelData.ScoreList.Count - maxScoreEntries);
            }

            SaveHighscores(scoreModelData, mode);
        }

        public void InsertScore(string name, int score, int moves, int time)
        {
            if (name.Length == 0)
            {
                name = "Player";
            }

            ScoreModel scoreModel = new ScoreModel();
            scoreModel.name = name;
            scoreModel.score = score;
           // scoreModel.time = time;
            scoreModel.moves = moves;
            scoreModel.date = System.DateTime.Now.ToString("dd.MM.yyyy");

            int mode = 0;

            AddHighscore(scoreModel, mode);
        }

        public ScoreModelData GetSavedScores(int mode)
        {
            string strPath = localPathO;

            if (mode == 1)
            {
                strPath = localPathV;
            }

            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
                ScoreModelData scoreModelData = new ScoreModelData();
                SaveHighscores(scoreModelData, mode);
            }

            using (StreamReader stream = new StreamReader(strPath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreModelData>(json);
            }
        }

        private void SaveHighscores(ScoreModelData scoreModelData, int mode)
        {
            string strPath = localPathO;

            if (mode == 1)
            {
                strPath = localPathV;
            }

            using (StreamWriter stream = new StreamWriter(strPath))
            {
                string json = JsonUtility.ToJson(scoreModelData, true);

                stream.Write(json);
            }
        }

        public void DeleteAllScores(int mode)
        {
            ScoreModelData scoreModelData = new ScoreModelData();
            SaveHighscores(scoreModelData, mode);
            ShowScores(GetSavedScores(mode));
        }

        public void ShowScores(ScoreModelData smd, int wScore = 0, string wName = "")
        {
            foreach (Transform child in Holder)
            {
                Destroy(child.gameObject);
            }

            float h = -10f;

            Holder.sizeDelta = new Vector2(820f, (smd.ScoreList.Count * 130f) + 20f);
            for (int i = 0; i < smd.ScoreList.Count; i++)
            {
                
                GameObject tmpObject = Instantiate(scorePrefab, Holder);
                tmpObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f,h);
                h -= 130f;
                ScoreModel tmpScore = smd.ScoreList[i];
                tmpObject.GetComponent<HighscoreScript>().SetScore((i + 1).ToString(), tmpScore.score.ToString(), tmpScore.name, tmpScore.moves.ToString(), tmpScore.date.ToString());

                if (wScore > 0)
                {
                    if (tmpScore.score == wScore && tmpScore.name == wName)
                    {
                        tmpObject.GetComponent<Image>().color = new Color32(255, 247, 153, 255);

                    }
                }
            }
        }

        public void clearUiScores()
        {
            foreach (Transform child in Holder)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
