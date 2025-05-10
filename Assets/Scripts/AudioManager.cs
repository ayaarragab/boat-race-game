using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    [Header("Pitch Randomization")]
    [SerializeField] private float minPitch = 0.75f;
    [SerializeField] private float maxPitch = 1.25f;
    [SerializeField] private float maxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Uncomment the next line if you want AudioManager to persist across scenes
            // DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.volume = maxVolume;
        audioSource.PlayOneShot(clip);
    }
}
