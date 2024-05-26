using System;
using UnityEngine;
using UnityEngine.Events;

public class Laptop : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _CallDuration;
    [SerializeField] private UnityEvent _onOnlineCallEnded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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

        _onOnlineCallEnded.Invoke();
    }

    public void OnPhoneCallEndedHandle()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Activate");
    }
}
