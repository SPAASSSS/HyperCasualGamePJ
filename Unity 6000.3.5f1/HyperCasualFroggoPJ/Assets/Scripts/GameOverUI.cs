using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string titleSceneName = "TitleScene";
    [SerializeField] private TextMeshProUGUI bestFlyText;


    void Awake()
    {
        Hide();
    }

    public void Show()
    {
        ScoreManager.I.CommitHighScore();

        if (bestFlyText) bestFlyText.text = "Best: " + ScoreManager.I.HighScore;

        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(titleSceneName);
    }
}
