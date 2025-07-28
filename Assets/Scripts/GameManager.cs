using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables List
    public int score = 0;
    public int highScore = 0;
    public bool gameOver = false;
    public bool levelComplete = false;
    public bool hasGameStarted = false;
    public Rigidbody playerControllerRigidbody;


    //Singleton Pattern
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindFirstObjectByType<GameManager>();
            }
            return _instance;
        }
    }

    //Function Lists

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        hasGameStarted = false;
        if (playerControllerRigidbody != null)
        {
            playerControllerRigidbody.isKinematic = true; // Disable physics initially
        }
        //playerControllerRigidbody.gravityScale = 0;
    }

    public void GameStart()
    {
        hasGameStarted = true;
        gameOver = false;
        Time.timeScale = 1f;

        if (playerControllerRigidbody != null)
        {
            playerControllerRigidbody.isKinematic = true;  // Disable physics initially
        }
        //playerControllerRigidbody.gravityScale = 1;
    }


    public void GameOver()
    {
        gameOver = true;
        hasGameStarted = false; // Add this
        print("message");
        //AudioManager.Instance.PlayGameOverSound();
        UIManager.Instance.HandleGameOverUI();
        AudioManager.Instance.PlayGameOverSound();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Highscore", highScore);
    }

    public void Score()
    {
        score++;
        UIManager.Instance.UpdateUserScore(score);
        if (highScore < score)
        {
            highScore = score;
            SaveGame();
        }

        AudioManager.Instance.PlayScoreSound();
    }
    public void LevelComplete()
    {
        levelComplete = true;
        hasGameStarted = false; // Add this
        Score();
        print("message");
        UIManager.Instance.HandleLevelComplete();
        //AudioManager.Instance.PlayGameOverSound();
    }
}
