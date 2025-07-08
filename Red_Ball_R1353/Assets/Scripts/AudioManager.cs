using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip scoreSound;
    public AudioClip gameOverSound;
    public AudioClip jumpSound;
    public AudioClip enemySound;
    public AudioClip enemyKillSound;

    private static AudioManager _instance;
    private AudioSource audioSource;

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

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayEnemySound()
    {
        audioSource.PlayOneShot(enemySound);
    }

    public void PlayEnemyKillSound()
    {
        audioSource.PlayOneShot(enemyKillSound);
    }
}
