using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class StopDoorShakingSound : MonoBehaviour
{
    private StudioEventEmitter doorShakeEmitter;

    // Start is called before the first frame update
    void Start()
    {
        doorShakeEmitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
