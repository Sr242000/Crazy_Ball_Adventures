using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip scoreSound;
    public AudioClip gameOverSound;

    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindFirstObjectByType<AudioManager>();
            }
            return _instance;
        }
    }

    public void PlayScoreSound()
    {

        AudioSource.PlayClipAtPoint(scoreSound, Camera.main.transform.position);
    }
    public void PlayGameOverSound()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
    }
}
