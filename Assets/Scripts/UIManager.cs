using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameUIPanel;
    public GameObject LevelCompletePanel;
    public GameObject PausePanel;
    public GameObject HelpPanel;
    public GameObject MainMenuUI;
    public TMP_Text scoreText;
    public TMP_Text gameUI_ScoreText;
    public TMP_Text levelcomplete_ScoreText;

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
        levelcomplete_ScoreText.text = "Your High Score: " + GameManager.Instance.score;
        print("calling here to");
        Time.timeScale = 0f;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HandleLevelComplete()
    {
        LevelCompletePanel.SetActive(true);
        gameUIPanel.SetActive(false); // Optional: Hide in-game UI
        scoreText.text = "Your High Score: " + GameManager.Instance.score;
        levelcomplete_ScoreText.text = "Your High Score: " + GameManager.Instance.score;
        print("highscore : "+GameManager.Instance.score);
        Time.timeScale = 0f; // Pause game
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // Resume game time in case it was paused
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels. Restarting at level 1.");
            SceneManager.LoadScene(0); // Or show a final screen
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume time before switching scenes
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameManager.Instance.hasGameStarted)
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ShowHelpPanel()
    {
        HelpPanel.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void HideHelpPanel()
    {
        HelpPanel.SetActive(false);
        MainMenuUI.SetActive(true);
    }



    public void ExitGame()
    {
        GameManager.Instance.SaveGame();
        Application.Quit();
    }


}
