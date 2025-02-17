using UnityEngine;
using TMPro; // Import TextMeshPro

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; } // Singleton Pattern
        private int score = 0; // save score

        public TextMeshProUGUI scoreText; // use TextMeshProUGUI

        private void Awake()
        {
            // system Singleton Pattern
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            LoadScore();
        }

        private void Start()
        {
            scoreText = FindObjectOfType<TextMeshProUGUI>(); // Auto-assign in new scenes
            UpdateScoreUI(); // update UI when game start
        }

        // add score
        public void AddScore(int points)
        {
            if (Instance == null)
            {
                Debug.LogError("ScoreManager Instance is NULL!");
                return;
            }

            score += points;
            SaveScore();
            UpdateScoreUI();
            Debug.Log("Score Added! Current Score: " + score);
        }

        //  add score now
        public int GetScore()
        {
            return score;
        }

        //  update UI show score
        private void UpdateScoreUI()
        {
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score.ToString();
            }
            else
            {
                Debug.LogError(" ScoreText chưa được gán trong Inspector!");
            }
        }
        private void SaveScore()
        {
            PlayerPrefs.SetInt("SavedScore", score);
            PlayerPrefs.Save();
        }
        private void LoadScore()
        {
            if (PlayerPrefs.HasKey("SavedScore"))
            {
                score = PlayerPrefs.GetInt("SavedScore", 0);
            }
            else
            {
                score = 0;
            }
        }

        public void ResetScore() // Call this when starting a new game
        {
            score = 0;
            PlayerPrefs.SetInt("SavedScore", score);
            PlayerPrefs.Save();
            UpdateScoreUI();
        }

    }



}
