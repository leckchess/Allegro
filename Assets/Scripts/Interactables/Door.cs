using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private const float TIME = 0.2f;

    [SerializeField] private Transform _door;
    [SerializeField] private bool _isOpen;

    private Quaternion _openRotation;
    private Coroutine _rotationCoroutine;

    private void Awake()
    {
        _openRotation = Quaternion.Euler(0, 90, 0);
        _door.localRotation = _isOpen ? _openRotation : Quaternion.identity;
    }

    public override void Interact()
    {
        base.Interact();
        if (_rotationCoroutine != null) StopCoroutine(_rotationCoroutine);
        _isOpen = !_isOpen;
        _rotationCoroutine = StartCoroutine(Rotate(_isOpen ? _openRotation : Quaternion.identity));
    }

    IEnumerator Rotate(Quaternion targetRotation)
    {
        Quaternion currentRotation = _door.localRotation;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.02f);

            _door.localRotation = Quaternion.Lerp(currentRotation, targetRotation, (i + 1) / 20f);
        }

        _rotationCoroutine = null;
    }
}