using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Interactable
{
    [SerializeField] private Animator _animator;
    private bool _isOpen = true;
    public override void Interact()
    {
        base.Interact();
        _isOpen = !_isOpen;
        _animator.enabled = _isOpen;
    }
}
