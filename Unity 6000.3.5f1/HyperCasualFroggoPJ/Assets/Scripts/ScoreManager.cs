using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager I;

    const string HIGH_KEY = "HighFly";

    public int score = 0;
    public int HighScore { get; private set; }

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        I = this;
        HighScore = PlayerPrefs.GetInt(HIGH_KEY, 0);
        UpdateUI();
    }

    public void Add(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void ResetRun()
    {
        score = 0;
        UpdateUI();
    }

    public void CommitHighScore()
    {
        if (score > HighScore)
        {
            HighScore = score;
            PlayerPrefs.SetInt(HIGH_KEY, HighScore);
            PlayerPrefs.Save();
        }
    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = ": " + score;
    }
}
