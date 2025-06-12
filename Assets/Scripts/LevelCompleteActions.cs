using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteActions : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Change this to match your Main Menu scene name

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
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
