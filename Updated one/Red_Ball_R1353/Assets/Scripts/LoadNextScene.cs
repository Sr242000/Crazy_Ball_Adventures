using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void StartMyGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FlyingBall");
    }
}
