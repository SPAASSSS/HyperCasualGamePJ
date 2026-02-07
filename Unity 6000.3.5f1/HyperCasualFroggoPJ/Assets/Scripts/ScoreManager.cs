using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager I;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        I = this;
        UpdateUI();
    }

    public void Add(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText) scoreText.text = "Fly: " + score;
    }
}
