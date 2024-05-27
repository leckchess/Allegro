using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundParameter : MonoBehaviour
{
    [SerializeField] int parameter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMusic()
    {
        if (parameter == 1) {
            FMODAudioManager.Instance.PlayFearMusic();
        }
    }
}
