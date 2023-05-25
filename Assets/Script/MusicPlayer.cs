using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;  // Reference to your music clip

    private static MusicPlayer instance;  // Static reference to the MusicPlayer instance

    private AudioSource audioSource;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // Destroy duplicate instances
            Destroy(gameObject);
            return;
        }

        // Set the instance
        instance = this;

        // Keep the MusicPlayer alive between scene changes
        DontDestroyOnLoad(gameObject);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Play the music on start
        PlayMusic();
    }

    private void PlayMusic()
    {
        // Set the music clip to play
        audioSource.clip = musicClip;

        // Play the music
        audioSource.Play();
    }
}
