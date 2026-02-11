using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] private GameOverUI gameOverUI;

    public bool IsGameOver { get; private set; }

    void Awake()
    {
        I = this;
        Time.timeScale = 1f;
        IsGameOver = false;
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;

        Time.timeScale = 0f;
        gameOverUI.Show();
    }
}
