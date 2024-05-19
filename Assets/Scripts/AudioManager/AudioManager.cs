using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private Dictionary<string, AudioSource> musicSources = new Dictionary<string, AudioSource>();
    private List<AudioSource> sfxSources = new List<AudioSource>();

    [SerializeField] private AudioSource bgMusicSourcePrefab;
    [SerializeField] private AudioSource sfxSourcePrefab;
    [SerializeField] private int initialSfxSourceCount = 10;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize SFX sources pool
        for (int i = 0; i < initialSfxSourceCount; i++)
        {
            AudioSource source = Instantiate(sfxSourcePrefab, transform);
            source.playOnAwake = false;
            sfxSources.Add(source);
        }
    }

    public void PlayMusic(string trackName, AudioClip clip, bool loop = true)
    {
        if (!musicSources.ContainsKey(trackName))
        {
            AudioSource source = Instantiate(bgMusicSourcePrefab, transform);
            source.clip = clip;
            source.loop = loop;
            source.Play();
            musicSources[trackName] = source;
        }
        else
        {
            AudioSource source = musicSources[trackName];
            source.clip = clip;
            source.loop = loop;
            source.Play();
        }
    }

    public void StopMusic(string trackName)
    {
        if (musicSources.ContainsKey(trackName))
        {
            musicSources[trackName].Stop();
            Destroy(musicSources[trackName].gameObject);
            musicSources.Remove(trackName);
        }
    }

    public void StopAllMusic()
    {
        foreach (var source in musicSources.Values)
        {
            source.Stop();
            Destroy(source.gameObject);
        }
        musicSources.Clear();
    }

    public void PlayOneShot(AudioClip clip)
    {
        AudioSource availableSource = sfxSources.Find(source => !source.isPlaying);

        if (availableSource == null)
        {
            availableSource = Instantiate(sfxSourcePrefab, transform);
            availableSource.playOnAwake = false;
            sfxSources.Add(availableSource);
        }

        availableSource.PlayOneShot(clip);
    }
}
