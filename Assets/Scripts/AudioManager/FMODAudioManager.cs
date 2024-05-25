using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODAudioManager : MonoBehaviour
{
    // Singleton instance
    public static FMODAudioManager Instance { get; private set; }

    private StudioEventEmitter musicEmitter;

    [EventRef]
    public string sfxEvent; // Reference to the FMOD event for sound effects

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get the FMOD Studio Event Emitter component attached to the main camera
        musicEmitter = Camera.main.GetComponent<StudioEventEmitter>();

        if (musicEmitter == null)
        {
            Debug.LogError("No FMOD Studio Event Emitter found on the main camera.");
        }
    }

    public void PlayInitialMusic()
    {
        SetMusicParameter(0.0f); // 0 for initial music
    }

    public void PlayFearMusic()
    {
        SetMusicParameter(1.0f); // 1 for fear music
    }

    public void PlayHappyMusic()
    {
        SetMusicParameter(2.0f); // 2 for happy music
    }

    private void SetMusicParameter(float value)
    {
        if (musicEmitter != null && musicEmitter.IsActive)
        {
            musicEmitter.EventInstance.setParameterByName("Mselector", value);
        }
        else
        {
            Debug.LogWarning("Music emitter is null or not active.");
        }
    }

    public void PlaySFX()
    {
        if (!string.IsNullOrEmpty(sfxEvent))
        {
            RuntimeManager.PlayOneShot(sfxEvent);
        }
        else
        {
            Debug.LogWarning("SFX event path is not set.");
        }
    }
}
