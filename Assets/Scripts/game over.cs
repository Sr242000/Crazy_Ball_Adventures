using UnityEngine;
using UnityEngine.SceneManagement; // Scene reload ke liye

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if it's the player
        {
            // Optionally: You can also destroy the player
            Destroy(collision.gameObject);

            // Restart the level after short delay
            Invoke("RestartLevel", 0.5f); // 0.5 seconds delay
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
