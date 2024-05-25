using UnityEngine;

public class ExampleFMODTest : MonoBehaviour
{
    void Update()
    {
        // Check for space bar press to play fear music
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FMODAudioManager.Instance.PlayFearMusic();
        }

        // Check for 'A' key press to play happy music
        if (Input.GetKeyDown(KeyCode.A))
        {
            FMODAudioManager.Instance.PlayHappyMusic();
        }
    }
}
