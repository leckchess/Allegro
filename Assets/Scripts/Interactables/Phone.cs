using System;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class Phone : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _CallDuration;

    [SerializeField] private UnityEvent OnPhoneCallEnded;

    [SerializeField] private StudioEventEmitter phoneRingEmitter;
    [SerializeField]  private EventReference phonePickUpEvent;
    [SerializeField]  private EventReference phoneUIDialogeEvent;
    [SerializeField]  private EventReference phoneCutEvent;
    [SerializeField]  private EventReference VOEvent;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        phoneRingEmitter = GetComponent<StudioEventEmitter>();
    }

    public override void Interact()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Answer");
        if (phoneRingEmitter != null && phoneRingEmitter.IsPlaying())
        {
            phoneRingEmitter.Stop();
            RuntimeManager.PlayOneShot(phonePickUpEvent);
        }

        RuntimeManager.PlayOneShot(phoneUIDialogeEvent);

        Invoke("EndCall", _CallDuration);
    }

    private void EndCall()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("EndCall");

        RuntimeManager.PlayOneShot(phoneCutEvent);

        OnPhoneCallEnded.Invoke();
    }

    public void PlayAudio()
    {
        RuntimeManager.PlayOneShot(VOEvent);
    }
}
