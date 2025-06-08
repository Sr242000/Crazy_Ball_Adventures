using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameUIPanel;
    //public GameObject LevelCompletePanel;
    public TMP_Text scoreText;
    public TMP_Text gameUI_ScoreText;

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindFirstObjectByType<UIManager>();
            }
            return _instance;
        }
    }

    public void UpdateUserScore(int score)
    {
        gameUI_ScoreText.text = score.ToString();
    }

    public void HandleGameOverUI()
    {
        gameOverPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        scoreText.text = "Your High Score: " + GameManager.Instance.score;
        Time.timeScale = 0f;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveGame();
        Application.Quit();
    }
}
