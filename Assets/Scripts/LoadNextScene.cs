using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void StartMyGame()
    {
        SceneManager.LoadScene("FlyingBall");
    }
}
