using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Fan : Interactable
{
    [SerializeField] private Animator _animator;
    private bool _isOpen = true;
    [SerializeField] private EventReference fanStopEvent;
    private StudioEventEmitter fanStartEmitter;

    public override void Interact()
    {
        base.Interact();
        _isOpen = !_isOpen;
        _animator.enabled = _isOpen;
        fanStartEmitter = GetComponent<StudioEventEmitter>();

        if (_isOpen) {
            // Fan is rotating
            // Play the fan rotating sound
            if (fanStartEmitter != null && !fanStartEmitter.IsPlaying())
            {
                RuntimeManager.PlayOneShot(fanStopEvent);
                fanStartEmitter.Play();
            }
        } else {
            // Fan is stoped

            if (fanStartEmitter != null && fanStartEmitter.IsPlaying())
            {
                fanStartEmitter.Stop();
            }
            RuntimeManager.PlayOneShot(fanStopEvent);
        }
    }
}
