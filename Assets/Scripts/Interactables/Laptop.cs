using System;
using UnityEngine;

public class Laptop : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _CallDuration;

    public static event Action OnOnlineCallEnded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Phone.OnPhoneCallEnded += OnPhoneCallEndedHandle;
    }

    public override void Interact()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Open");

        Invoke("EndCall", _CallDuration);
    }

    private void EndCall()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Close");

        OnOnlineCallEnded?.Invoke();
    }

    public void OnPhoneCallEndedHandle()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Activate");
    }
}
