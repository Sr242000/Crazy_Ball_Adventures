using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameUIPanel;
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
        scoreText.text = "Your Score: " + GameManager.Instance.score;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("FlyingBall");
    }

    public void ExitGame()
    {
        GameManager.Instance.SaveGame();
        Application.Quit();
    }
}
