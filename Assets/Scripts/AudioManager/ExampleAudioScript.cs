using UnityEngine;

public class AudioManagerUsageExample : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusicClip1;
    [SerializeField] private AudioClip backgroundMusicClip2;
    [SerializeField] private AudioClip uiClickSoundClip;
    [SerializeField] private AudioClip interactionSoundClip;

    private void Start()
    {
    
        AudioManager.Instance.PlayMusic("BackgroundTrack1", backgroundMusicClip1, true);

   
        //AudioManager.Instance.PlayMusic("BackgroundTrack2", backgroundMusicClip2, true);
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlayOneShot(uiClickSoundClip);
        }

    
        if (Input.GetKeyDown(KeyCode.I))
        {
            AudioManager.Instance.PlayOneShot(interactionSoundClip);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioManager.Instance.PlayMusic("BackgroundTrack1", backgroundMusicClip1, true);
        }

      
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioManager.Instance.StopMusic("BackgroundTrack2");
        }

       
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.Instance.StopAllMusic();
        }
    }
}
