using System;
using UnityEngine;
using UnityEngine.Events;

public class Phone : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _CallDuration;

    [SerializeField] private UnityEvent OnPhoneCallEnded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Answer");

        Invoke("EndCall", _CallDuration);
    }

    private void EndCall()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("EndCall");

        OnPhoneCallEnded.Invoke();
    }
}
