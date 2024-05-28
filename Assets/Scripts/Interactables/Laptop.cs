using System;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class Laptop : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _CallDuration;
    [SerializeField] private UnityEvent _onOnlineCallEnded;
    [SerializeField] private EventReference laptopOpenEventMusic;
    [SerializeField] private EventReference laptopCloseEventMusic;
    [SerializeField] private EventReference VOEvent;

    [SerializeField] private AudioClip _voiceOverAudio;

    private AudioSource _voiceOverAudioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _voiceOverAudioSource = gameObject.AddComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Open");
        RuntimeManager.PlayOneShot(laptopOpenEventMusic);

        Invoke("EndCall", _CallDuration);
    }

    private void EndCall()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Close");
        RuntimeManager.PlayOneShot(laptopCloseEventMusic);


        _onOnlineCallEnded.Invoke();
    }

    public void OnPhoneCallEndedHandle()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Activate");
    }

    public void PlayAudio()
    {
        RuntimeManager.PlayOneShot(VOEvent);
    }
}
