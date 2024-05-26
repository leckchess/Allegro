using System;
using UnityEngine;

public class Phone : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _CallDuration;

    public static event Action OnPhoneCallEnded;

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

        OnPhoneCallEnded?.Invoke();
    }
}
